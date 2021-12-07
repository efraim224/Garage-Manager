using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private const string k_AppName = "Facebook App";
        private const string k_GroupWasCreatedMessage = "Party group was created!";
        private const string k_EnterALocationMessage = "Please enter a location first";
        private const string k_LoginName = "Login";
        private const string k_WrongInputInDaysAheadView = "Wrong input, you must enter a number between 1-365";
        private const string k_NoValidChoises = "You need to select your options :)";
        private const string k_NotEnoughtFriends = "You dont have enought friends for that option";
        private const string k_NoBestOption = "There is no Best option, everyone is good";
        private const string k_NotOpenOption = "Facebook closed the option.. try to search by yourself";
        private const string k_NoMatchesFound = "No matches found :(";
        private User m_LoggedInUser;
        private User m_FriendChosenBirthdayParty;
        private User[] m_UserFriendArray;
        private LoginResult m_LoginResult;

        public FormMain()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 100;
            buttonsLock();
            this.Text = k_AppName;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            m_LoginResult = FacebookService.Login(
                    //// (This is Desig Patter's App ID. replace it with your own - 1450160541956417)
                    "248100547353201", 
                    //// requested permissions:
					"email",
                    "public_profile",
                    "user_photos",
                    "user_posts",
                    "publish_to_groups",
                    "user_friends",
                    "user_events");

            if(!string.IsNullOrEmpty(m_LoginResult.AccessToken))
            {
                m_LoggedInUser = m_LoginResult.LoggedInUser;
                fetchUserInfo();
                buttonsUnlock();
                buttonLogin.Text = $"Logged in as {m_LoginResult.LoggedInUser.Name}";
                this.buttonLogin.Enabled = false;
            }
            else
            {
                MessageBox.Show(m_LoginResult.ErrorMessage, "Login Failed");
            }
        }

        private void fetchUserInfo()
        {
            pictureBoxProfile.LoadAsync(m_LoggedInUser.PictureNormalURL);
            pictureBoxProfile.SizeMode = PictureBoxSizeMode.StretchImage;
            m_UserFriendArray = new User[m_LoggedInUser.Friends.Count + 1];
            loadFriendToBirthdayPartyGrid();
            loadFriendsToTabFriends();
        }

        private void loadFriendsToTabFriends()
        {
            listBoxActiveFriends.Items.Clear();
            listBoxAllFriends.Items.Clear();
            listBoxOfflineFriends.Items.Clear();
            foreach(User currentUser in m_LoggedInUser.Friends)
            {
                listBoxAllFriends.Items.Add(currentUser);
                if (currentUser.OnlineStatus.Equals(User.eOnlineStatus.active))
                {
                    listBoxActiveFriends.Items.Add(currentUser);
                }
                else if (currentUser.OnlineStatus.Equals(User.eOnlineStatus.offline))
                {
                    listBoxOfflineFriends.Items.Add(currentUser);
                }
            }
        }

        private void loadFriendToBirthdayPartyGrid()
        {
            foreach(User friend in m_LoggedInUser.Friends)
            {
                this.dataGridFriendsToInvite.Rows.Add(friend.Name, false);
                m_UserFriendArray[this.dataGridFriendsToInvite.Rows.Count] = friend;
            }

            this.dataGridFriendsToInvite.Rows.Add(m_LoggedInUser.Name, false);
        }

        private void buttonsUnlock()
        {
            foreach(Button button in this.tabPageHomePage.Controls.OfType<Button>())
            {
                button.Enabled = true;
            }

            foreach(TabPage tab in this.tabControl1.TabPages)
            {
                tab.Enabled = true;
            }
        }

        private void buttonsLock()
        {
            foreach (Button button in this.tabPageHomePage.Controls.OfType<Button>())
            {
                button.Enabled = false;
            }

            foreach (TabPage tab in this.tabControl1.TabPages)
            {
                if (tab == this.tabPageHomePage)
                {
                    continue;
                }

                tab.Enabled = false;
            }

            this.buttonLogin.Enabled = true;
        }

        private void clearAllBoxes()
        {
            //// post box clear
            textBoxStatus.Clear();
            //// list box clear
            foreach (TabPage tabPage in this.tabControl1.Controls)
            {
                      Clear(tabPage);
            }
        }

        private void Clear(TabPage i_TabPage)
        {
            foreach (Control currentControl in i_TabPage.Controls)
            {
                if (currentControl is RichTextBox)
                {
                    RichTextBox textBox = currentControl as RichTextBox;
                    textBox.Clear();
                }
                else if (currentControl is DataGridView)
                {
                    DataGridView grid = currentControl as DataGridView;
                    grid.Rows.Clear();
                }
                else if (currentControl is ListBox)
                {
                    ListBox list = currentControl as ListBox;
                    list.Items.Clear();
                }
                else if (currentControl is TextBox)
                {
                    TextBox box = currentControl as TextBox;
                    box.Clear();
                }
                else if(currentControl is PictureBox)
                {
                    PictureBox pic = currentControl as PictureBox;
                    pic.Image = null;
                }
            }
        }

        private void buttonPostStatus_Click(object sender, EventArgs e)
        {
            postStatus();
        }

        private void postStatus()
        {
            try
            {
                Status postedStatus = m_LoggedInUser.PostStatus(textBoxStatus.Text);
                MessageBox.Show("Status Posted! ID: " + postedStatus.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonResetTextBox_Click(object sender, EventArgs e)
        {
            textBoxStatus.Text = string.Empty;
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.LogoutWithUI();
            m_LoginResult = null;
            clearAllBoxes();
            buttonsLock();
            buttonLogin.Text = k_LoginName;
        }

        private void buttonFetchPosts_Click(object sender, EventArgs e)
        {
            fetchPosts();
        }

        private void fetchPosts()
        {
            listBoxPosts.Items.Clear();

            foreach (Post post in m_LoggedInUser.Posts)
            {
                if (post.Message != null)
                {
                    listBoxPosts.Items.Add(post.Message);
                }
                else if (post.Caption != null)
                {
                    listBoxPosts.Items.Add(post.Caption);
                }
                else
                {
                    listBoxPosts.Items.Add(string.Format("[{0}]", post.Type));
                }
            }

            if (listBoxPosts.Items.Count == 0)
            {
                MessageBox.Show("No Posts to retrieve :(");
            }
        }

        private void fetchAlbums()
        {
            listBoxAlbums.Items.Clear();
            listBoxAlbums.DisplayMember = "Name";
            foreach (Album album in m_LoggedInUser.Albums)
            {
                listBoxAlbums.Items.Add(album);
            }

            if (listBoxAlbums.Items.Count == 0)
            {
                MessageBox.Show("No Albums to retrieve :(");
            }
        }

        private void listBoxAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            displaySelectedAlbum();
        }

        private void displaySelectedAlbum()
        {
            if (listBoxAlbums.SelectedItems.Count == 1)
            {
                Album selectedAlbum = listBoxAlbums.SelectedItem as Album;
                if (selectedAlbum.PictureAlbumURL != null)
                {
                    pictureBoxAlbum.LoadAsync(selectedAlbum.PictureAlbumURL);
                }
                else
                {
                    pictureBoxAlbum.Image = pictureBoxAlbum.ErrorImage;
                }

                pictureBoxAlbum.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void listBoxPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Post selected = m_LoggedInUser.Posts[listBoxPosts.SelectedIndex];
            this.listBoxComments.Items.Clear();
            listBoxComments.DisplayMember = "Message";
            foreach (Comment comment in selected.Comments)
            {
                this.listBoxComments.Items.Add(comment);
            }
        }

        private void listBoxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxGroups.SelectedItems.Count == 1)
            {
                Group selectedGroup = listBoxGroups.SelectedItem as Group;
                if (selectedGroup.PictureNormalURL != null)
                {
                    pictureBoxGroup.LoadAsync(selectedGroup.PictureNormalURL);
                }
                else
                {
                    pictureBoxGroup.Image = pictureBoxGroup.ErrorImage;
                }

                pictureBoxAlbum.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void buttonFetchEvents_Click(object sender, EventArgs e)
        {
            fetchEvents();
        }

        private void fetchEvents()
        {
            listBoxEvents.Items.Clear();
            listBoxEvents.DisplayMember = "Name";
            foreach (Event fbEvent in m_LoggedInUser.Events)
            {
                listBoxEvents.Items.Add(fbEvent);
            }

            if (listBoxEvents.Items.Count == 0)
            {
                MessageBox.Show("No Events to retrieve :(");
            }
        }

        private void listBoxEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            showEventPicture();
        }

        private void showEventPicture()
        {
            if (listBoxEvents.SelectedItems.Count == 1)
            {
                Event selectedEvent = listBoxEvents.SelectedItem as Event;
                if (selectedEvent.PictureNormalURL != null)
                {
                    pictureBoxEvent.LoadAsync(selectedEvent.Cover.SourceURL);
                }

                pictureBoxEvent.Image = pictureBoxEvent.ErrorImage;
                pictureBoxEvent.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void buttonSelectFriendBirthday_Click(object sender, EventArgs e)
        {
            if(!isLegalNumberOfDays(out int numberOfDaysInAdvance))
            {
                MessageBox.Show(k_WrongInputInDaysAheadView);
            }
            else
            {
                getFriendsWithinDaysAhead(numberOfDaysInAdvance);
            }
        }

        private bool isLegalNumberOfDays(out int o_NumberOfDaysInAdvance)
        {
            bool isLegal;
            if (!int.TryParse(
                   this.textBoxViewBirthdayIn.Text,
                   out o_NumberOfDaysInAdvance)
               || o_NumberOfDaysInAdvance > 365
               || o_NumberOfDaysInAdvance < 1)
            {
                isLegal = false;
            }
            else
            {
                isLegal = true;
            }

            return isLegal;
        }

        private void getFriendsWithinDaysAhead(int i_DaysAhead)
        {
            this.comboBoxSelectedFriendForBirthday.Items.Clear();
            try
            {
                if(m_LoggedInUser != null)
                {
                    foreach(User friend in m_LoggedInUser.Friends)
                    {
                        addFriendIfUpcomingBirthday(friend, i_DaysAhead);
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void addFriendIfUpcomingBirthday(User i_Friend, int i_DaysAhead)
        {
            DateTime birthday;
            if (
                DateTime.TryParseExact(
                    i_Friend.Birthday,
                "MM/dd/yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                out birthday))
            {
                DateTime upcomingBirthday = new DateTime(DateTime.Now.Year, birthday.Month, birthday.Day);
                if (DateTime.Now > upcomingBirthday.Date)
                {
                    upcomingBirthday = new DateTime(DateTime.Now.Year + 1, birthday.Month, birthday.Day);
                }

                if (DateTime.Now.AddDays(i_DaysAhead) >= upcomingBirthday.Date
                    && upcomingBirthday.Date >= DateTime.Now)
                {
                    this.comboBoxSelectedFriendForBirthday.Items.Add(i_Friend);
                }
            }
        }

        private void comboBoxSelectedFriendForBirthday_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.comboBoxSelectedFriendForBirthday.SelectedItem != null)
            {
                m_FriendChosenBirthdayParty = this.comboBoxSelectedFriendForBirthday.SelectedItem as User;
            }
        }

        private void buttonCreateBirthdayParty_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBoxPartyLocation.Text))
            {
                MessageBox.Show(k_EnterALocationMessage);
            }
            else
            {
                createBirthdayPartyGroupAndPost();
                MessageBox.Show(k_GroupWasCreatedMessage);
            }
        }


        private void createBirthdayPartyGroupAndPost()
        {
            Group birthdayPartyGroup = new Group();

            try
            {
                if(m_FriendChosenBirthdayParty != null)
                {
                    foreach(DataGridViewRow row in dataGridFriendsToInvite.Rows)
                    {
                        if((row.Cells[2] as DataGridViewCheckBoxCell).Selected)
                        {
                            birthdayPartyGroup.Members.Add(m_UserFriendArray[row.Index]);
                        }
                    }
                    
                    birthdayPartyGroup.PostToWall(string.Format(
 @"hello all!!
We are planning a birthday party to {0} on the {1}!!
We will meet at {2}
Details in the description:
{3}",
 m_FriendChosenBirthdayParty.Name,
 dateTimePickerPartyDate.Value,
 textBoxPartyLocation,
 this.textBoxPartyInformation.Text));
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private List<User> getListOfMatchesByPrefrence(bool i_MalePrefrence, bool i_FemalePrefrence, User.eRelationshipStatus i_WantedStatus)
        {
            List<User> matches = new List<User>();
            foreach (User currentUser in m_LoggedInUser.Friends)
            {
                if (currentUser.Gender == User.eGender.male && i_MalePrefrence)
                {
                    if (currentUser.RelationshipStatus == i_WantedStatus)
                    {
                        matches.Add(currentUser);
                    }
                }

                if (currentUser.Gender == User.eGender.female && i_FemalePrefrence)
                {
                    if (currentUser.RelationshipStatus == i_WantedStatus)
                    {
                        matches.Add(currentUser);
                    }
                }
            }

            return matches;
        }

        private List<User> getListOfMatches(bool i_MalePrefrence, bool i_FemalePrefrence, string i_RelationshipTypeStr)
        {
            List<User> matches = new List<User>();
            if (i_RelationshipTypeStr.Equals("All"))
            {
                matches = getAllMatches(i_MalePrefrence, i_FemalePrefrence);
            }
            else
            {
                User.eRelationshipStatus wantedRelations = stringToRelationshipStatus(i_RelationshipTypeStr);
                matches = getListOfMatchesByPrefrence(i_MalePrefrence, i_FemalePrefrence, wantedRelations);
            }

            return matches;
        }

        private User.eRelationshipStatus stringToRelationshipStatus(string i_RelationshipEnumStr)
        {
            User.eRelationshipStatus status = 0;
            if(i_RelationshipEnumStr.Equals("Single"))
            {
                status = User.eRelationshipStatus.Single;
            }
            else if(i_RelationshipEnumStr.Equals("Divorced"))
            {
                status = User.eRelationshipStatus.Divorced;
            }
            else if(i_RelationshipEnumStr.Equals("In open relationship"))
            {
                status = User.eRelationshipStatus.InAnOpenRelationship;
            }

            return status;
        }

        private List<User> getAllMatches(bool i_MalePrefrence, bool i_FemalePrefrence)
        {
            List<User> allMatches = new List<User>();
            foreach (User currentUser in m_LoggedInUser.Friends)
            {
                if (i_MalePrefrence && currentUser.Gender == User.eGender.male)
                {
                    allMatches.Add(currentUser);
                }

                if (i_FemalePrefrence && currentUser.Gender == User.eGender.female)
                {
                    allMatches.Add(currentUser);
                }
            }

            return allMatches;
        }

        private void buttonLuckSearch_Click(object sender, EventArgs e)
        {
            showLuckyMatches();
        }

        private void showLuckyMatches()
        {
            int totalFriends = m_LoggedInUser.Friends.Count;
            if (totalFriends < 1)
            {
                MessageBox.Show(k_NotEnoughtFriends);
            }
            else
            {
                List<User> luckyMatches = new List<User>();
                Random rnd = new Random();
                int count = 0;
                int tries = 0;
                //// creating even possibility for each user, such that the max number is 10.
                while (count < 11 && tries < 20)
                {
                    int possibility = rnd.Next(0, totalFriends);
                    User current = m_LoggedInUser.Friends[possibility];
                    if (!luckyMatches.Contains(current))
                    {
                        luckyMatches.Add(current);
                        count++;
                    }

                    tries++;
                    if (luckyMatches.Count == totalFriends)
                    {
                        break;
                    }
                }

                insertToMatchDataGrid(luckyMatches);
            }
        }

        private void insertToMatchDataGrid(List<User> i_ListOfMatches)
        {
            dataGridViewMatches.Rows.Clear();
            if (i_ListOfMatches.Count == 0)
            {
                MessageBox.Show(k_NoMatchesFound);
            }
            else
            {
                foreach (User currentUser in i_ListOfMatches)
                {
                    {
                        dataGridViewMatches.Rows.Add(
                            currentUser,
                            currentUser.Name,
                            currentUser.Gender.ToString(),
                            currentUser.Location.Name,
                            currentUser.RelationshipStatus.ToString());
                    }
                }
            }
        }

        private void buttonRefreshFriends_Click(object sender, EventArgs e)
        {
            loadFriendsToTabFriends();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (!FemaleCheckBox.Checked && !MaleCheckBox.Checked)
            {
                MessageBox.Show(k_NoValidChoises);
            }
            else if (RelationshipComboBox.SelectedItem == null)
            {
                MessageBox.Show(k_NoValidChoises);
            }
            else
            {
                bool femalePrefrence = FemaleCheckBox.Checked;
                bool malePrefrence = MaleCheckBox.Checked;
                string relationshipType = RelationshipComboBox.SelectedItem as string;
                List<User> potentialFriends = new List<User>();
                potentialFriends = getListOfMatches(malePrefrence, femalePrefrence, relationshipType);
                insertToMatchDataGrid(potentialFriends);
            }
        }

        private void buttonFetchGroups_Click(object sender, EventArgs e)
        {
            listBoxGroups.Items.Clear();
            listBoxGroups.DisplayMember = "Name";

            try
            {
                foreach (Group group in m_LoggedInUser.Groups)
                {
                    listBoxGroups.Items.Add(group);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (listBoxGroups.Items.Count == 0)
            {
                MessageBox.Show("No groups to retrieve :(");
            }
        }

        private void buttonFetchAlbums_Click(object sender, EventArgs e)
        {
            fetchAlbums();
        }

        private void buttonSubscribers_Click(object sender, EventArgs e)
        {
            showSubscribersMatch();
        }

        private void showSubscribersMatch()
        {
            try
            {
                List<User> subscriberMatch = new List<User>();
                foreach (User currentUser in m_LoggedInUser.Subscribers)
                {
                    subscriberMatch.Add(currentUser);
                }

                foreach (User currentUser in m_LoggedInUser.SubscribedTo)
                {
                    subscriberMatch.Add(currentUser);
                }

                if (subscriberMatch.Count < 2)
                {
                    MessageBox.Show(k_NoBestOption);
                }
                else
                {
                    insertToMatchDataGrid(subscriberMatch);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
