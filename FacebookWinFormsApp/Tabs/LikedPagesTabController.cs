﻿using BasicFacebookFeatures.controllers;
using BasicFacebookFeatures.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Tabs
{
    public class LikedPagesTabController : BaseTabController
    {
        private IUserCardsFetcher IuserCardsFetcher = new DataToCardsFetcherAdapter();
        public LikedPagesTabController(FlowLayoutPanel flowLayoutPanel) : base(flowLayoutPanel) { }

        public override void Populate()
        {
            var likedPagesCards = IuserCardsFetcher.GetLikedPagesCards();

            foreach (var likedPagecard in likedPagesCards)
            {
                FlowLayoutPanel.Controls.Add(likedPagecard as ImageAndTitleCardItem);
            }
        }
    }
}