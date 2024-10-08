﻿using BasicFacebookFeatures.controllers;
using BasicFacebookFeatures.Data;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BasicFacebookFeatures.Data.Enums;

namespace BasicFacebookFeatures
{
    public partial class CreateCanvasScreen : Form
    {
        private const string k_NoAlbumsMessage = "There Are No Albums";
        private const string k_DisplayMemberName = "Name";
        private const string k_AddImageText = "Add Image Here";
        private const string k_FontName = "Arial";
        private const int k_FontSize = 10;
        private const FontStyle k_FontStyle = FontStyle.Bold;
        private const string k_SaveFileDialogFilter = "PNG Image (*.png)|*.png|JPEG Image (*.jpg)|*.jpg|All files (*.*)|*.*";
        private const string k_SuccessMessage = "Table layout saved as image.";
        private const string k_SuccessTitle = "Success";
        private const MessageBoxButtons k_OkButton = MessageBoxButtons.OK;
        private const MessageBoxIcon k_InformationIcon = MessageBoxIcon.Information;

        CreateCanvasController CreateCanvasController { get; set; }

        public CreateCanvasScreen()
        {
            InitializeComponent();
            CreateCanvasController = new CreateCanvasController();
        }

        private void addAlbumsToComboBox()
        {
            FacebookObjectCollection<Album> userAlbums = CreateCanvasController.UserAlbums;

            if (userAlbums != null)
            {
                comboBoxAlbumsNames.DisplayMember = k_DisplayMemberName;
                comboBoxAlbumsNames.DataSource = userAlbums;
            }

            else
            {
                comboBoxAlbumsNames.Text = k_NoAlbumsMessage;
            }
        }

        private void createTableLayoutFromUserChoice()
        {
            tableLayoutPanel.RowCount = CreateCanvasController.LayoutRaws;
            tableLayoutPanel.ColumnCount = CreateCanvasController.LayoutCols;
            setColAndRowsSameSizeOfTable();
            createButtonsForTableLayout();
        }

        private void setColAndRowsSameSizeOfTable()
        {
            for (int i = 0; i < tableLayoutPanel.RowCount; i++)
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / tableLayoutPanel.RowCount));
            }

            for (int i = 0; i < tableLayoutPanel.ColumnCount; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / tableLayoutPanel.ColumnCount));
            }
        }

        private void createButtonsForTableLayout()
        {
            tableLayoutPanel.Controls.Clear();
            for (int i = 0; i < CreateCanvasController.LayoutRaws; i++)
            {
                for (int j = 0; j < CreateCanvasController.LayoutCols; j++)
                {
                    Button addImageBtn = new Button
                    {
                        Text = k_AddImageText,
                        Dock = DockStyle.Fill,
                        Font = new Font(k_FontName, k_FontSize, k_FontStyle)
                    };

                    tableLayoutPanel.Controls.Add(addImageBtn, j, i);
                    addImageBtn.Click += createPictureBoxInsteadButton;
                }
            }
        }

        private void createPictureBoxInsteadButton(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                PictureBox pictureBox = new PictureBox
                {
                    Image = pictureBoxImagesFromAlbum.Image,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = clickedButton.Location,
                    Size = clickedButton.Size
                };

                TableLayoutPanelCellPosition pos = tableLayoutPanel.GetCellPosition(clickedButton);

                tableLayoutPanel.Controls.Add(pictureBox, pos.Column, pos.Row);
                tableLayoutPanel.Controls.Remove(clickedButton);
            }

            if (CheakTableIsFullInPictures())
            {
                buttonPostImage.Show();
            }
        }

        private void radioButtonTwoOnTwo_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTwoOnTwo.Checked)
            {
                CreateCanvasController.LayoutRaws = 2;
                CreateCanvasController.LayoutCols = 2;
                CreateCanvasController.LayoutSize = eLayoutSize.TWO_ON_TWO;
                createTableLayoutFromUserChoice();
                buttonPostImage.Hide();
            }
        }

        private void radioButtonOneOnTwo_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOneOnTwo.Checked)
            {
                CreateCanvasController.LayoutRaws = 1;
                CreateCanvasController.LayoutCols = 2;
                CreateCanvasController.LayoutSize = eLayoutSize.ONE_ON_TWO;
                createTableLayoutFromUserChoice();
                buttonPostImage.Hide();
            }
        }

        private void radioButtonThreeOnThree_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonThreeOnThree.Checked)
            {
                CreateCanvasController.LayoutRaws = 3;
                CreateCanvasController.LayoutCols = 3;
                CreateCanvasController.LayoutSize = eLayoutSize.THREE_ON_THREE;
                createTableLayoutFromUserChoice();
                buttonPostImage.Hide();
            }
        }

        private void comboBoxAlbumsNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAlbumsNames.SelectedItem is Album choosenAlbum)
            {
                CreateCanvasController.GetAllUserImagesFromAlbum(choosenAlbum);
                pictureBoxImagesFromAlbum.Image = choosenAlbum.ImageAlbum;
                CreateCanvasController.IndexUserImages = 0;
            }
        }

        private void buttonNextImage_Click(object sender, EventArgs e)
        {
            CreateCanvasController.IndexUserImages++;
            if (CreateCanvasController.UserPhotos.Count() > 0)
            {
                Photo photoToPresent = CreateCanvasController.UserPhotos.ElementAt(CreateCanvasController.IndexUserImages);
                pictureBoxImagesFromAlbum.Image = photoToPresent.ImageNormal;
            }
        }

        private void buttonBackImage_Click(object sender, EventArgs e)
        {
            CreateCanvasController.IndexUserImages--;
            if (CreateCanvasController.UserPhotos.Count() > 0)
            {
                Photo photoToPresent = CreateCanvasController.UserPhotos.ElementAt(CreateCanvasController.IndexUserImages);
                pictureBoxImagesFromAlbum.Image = photoToPresent.ImageNormal;
            }
        }

        private void AlbumsCreateScreen_Load(object sender, EventArgs e)
        {
            addAlbumsToComboBox();
            CreateCanvasController.LayoutRaws = 2;
            CreateCanvasController.LayoutCols = 2;
            CreateCanvasController.LayoutSize = eLayoutSize.TWO_ON_TWO;
            createTableLayoutFromUserChoice();
            buttonPostImage.Hide();
        }

        private void buttonPostImage_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = k_SaveFileDialogFilter })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    using (Bitmap bitmap = new Bitmap(tableLayoutPanel.Width, tableLayoutPanel.Height))
                    {
                        tableLayoutPanel.DrawToBitmap(bitmap, new Rectangle(0, 0, tableLayoutPanel.Width, tableLayoutPanel.Height));
                        bitmap.Save(filePath);
                    }

                    MessageBox.Show(k_SuccessMessage, k_SuccessTitle, k_OkButton, k_InformationIcon);
                }
            }
        }

        private bool CheakTableIsFullInPictures()
        {
            return tableLayoutPanel.Controls.OfType<PictureBox>().Count() == tableLayoutPanel.RowCount * tableLayoutPanel.ColumnCount;
        }
    }
}