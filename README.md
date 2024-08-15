<h1>Social Media Management System</h1>

<h2>Overview</h2>
<p>This project is a Social Media Management System designed to enhance user interaction with social media platforms by integrating with the Facebook API. The system provides additional features that allow users to send greeting cards, create custom canvases, and manage their profiles more efficiently, all while leveraging Facebook's existing services.</p>

<h2>Features</h2>
<h3>1. Sending Greeting Cards</h3>
<p><strong>Description:</strong> Users can select a friend from their list and send a pre-made greeting card, such as a birthday wish. The system automatically fills in the friend's name and the sender's name in the card. Additionally, users can post the greeting directly to their Facebook feed.</p>

<h3>2. Creating Custom Canvases</h3>
<p><strong>Description:</strong> Users can create a custom canvas composed of images from their Facebook photo albums. The user selects the canvas size (e.g., 3x3) and chooses which photos to place in each section of the canvas. The final canvas can be downloaded as a single image.</p>

<h2>MultiThreading Implementation</h2>
<p><strong>Description:</strong> Upon successful login, the system displays a loading screen while it retrieves user data (such as photos, posts, etc.) from Facebook using multiple threads. This parallel processing reduces data retrieval time and ensures a smoother user experience, transitioning to the main screen only when all data is ready.</p>

<h2>DataBinding Usage</h2>
<p><strong>Friends List:</strong> The system uses DataBinding to display a list of Facebook friends. When a friend is selected, their full name, profile picture, and editable nickname are shown.</p>

<h2>Design Patterns</h2>
<h3>1. Composite</h3>
<p><strong>Purpose:</strong> Organize photo albums by allowing users to group selected photos or albums into new albums, structured hierarchically like a tree.</p>

<h3>2. Decorator</h3>
<p><strong>Purpose:</strong> Enhance Facebook posts by adding features such as image insertion, background color changes, or tagging friends.</p>

<h3>3. Adapter</h3>
<p><strong>Purpose:</strong> Adapt the Facebook API to match the interface required by the system, allowing the reuse of Facebook's services without altering their original design.</p>

<h3>4. Proxy</h3>
<p><strong>Purpose:</strong> Act as an intermediary between the system and Facebook services to improve performance by caching data and providing functionality even when offline.</p>

<h2>Technologies Used</h2>
<ul>
  <li>Programming Language: C#</li>
  <li>Facebook API: For retrieving user data and interacting with Facebook services.</li>
  <li>MultiThreading: To enhance performance by loading data in parallel.</li>
  <li>DataBinding: For efficient display and update of user data.</li>
  <li>Design Patterns: Composite, Decorator, Adapter, Proxy</li>
</ul>

<h2>Screenshots</h2>
<ul>
  <li>Login Screen</li>
  <img src="https://github.com/user-attachments/assets/713f74e7-ab2d-40e6-ad4a-a2f994422555" alt="Login Screen">
  
  <li>Loading Screen</li>
  <img width="365" src="https://github.com/user-attachments/assets/c44c4b6d-cbc9-4193-a3ed-5f5c3d4129b1" alt="Loading Screen">
  
  <li>Main Screen</li>
  <img src="https://github.com/user-attachments/assets/8ac7ee72-e398-4628-9ab4-dd003e6da370" alt="Main Screen">
  
  <li>Business Card</li>
  <img src="https://github.com/user-attachments/assets/ad572375-cadd-4bbe-9878-a7eaf0f81473" alt="Business Card">
  
  <li>Create Canvas</li>
  <img src="https://github.com/user-attachments/assets/9cb3bd00-84b0-4889-b256-05e47f42c8b2" alt="Create Canvas">
  
  <li>Teams</li>
  <img src="https://github.com/user-attachments/assets/397112e9-3223-4d59-86aa-d9a52a87354e" alt="Teams">
  
  <li>Liked Pages</li>
  <img width="473" src="https://github.com/user-attachments/assets/55d43fae-4fc3-4552-8a68-dcbe234ea7b8" alt="Liked Pages">
  
  <li>Post</li>
  <img width="305" src="https://github.com/user-attachments/assets/0b808244-c286-445b-93da-934b26940cf9" alt="Post">
</ul>
