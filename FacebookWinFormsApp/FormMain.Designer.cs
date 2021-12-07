using System;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageHomePage = new System.Windows.Forms.TabPage();
            this.listBoxComments = new System.Windows.Forms.ListBox();
            this.listBoxPosts = new System.Windows.Forms.ListBox();
            this.listBoxEvents = new System.Windows.Forms.ListBox();
            this.listBoxGroups = new System.Windows.Forms.ListBox();
            this.buttonFetchEvents = new System.Windows.Forms.Button();
            this.buttonFetchGroups = new System.Windows.Forms.Button();
            this.pictureBoxEvent = new System.Windows.Forms.PictureBox();
            this.pictureBoxGroup = new System.Windows.Forms.PictureBox();
            this.pictureBoxAlbum = new System.Windows.Forms.PictureBox();
            this.listBoxAlbums = new System.Windows.Forms.ListBox();
            this.buttonFetchAlbums = new System.Windows.Forms.Button();
            this.buttonFetchPosts = new System.Windows.Forms.Button();
            this.labelComments = new System.Windows.Forms.Label();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonResetTextBox = new System.Windows.Forms.Button();
            this.buttonPostStatus = new System.Windows.Forms.Button();
            this.textBoxStatus = new System.Windows.Forms.RichTextBox();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.tabPagePlanBirthdayParty = new System.Windows.Forms.TabPage();
            this.textBoxPartyLocation = new System.Windows.Forms.TextBox();
            this.labelPartyLocation = new System.Windows.Forms.Label();
            this.labelPartyDate = new System.Windows.Forms.Label();
            this.dateTimePickerPartyDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxViewBirthdayIn = new System.Windows.Forms.TextBox();
            this.labelDays = new System.Windows.Forms.Label();
            this.buttonCreateBirthdayParty = new System.Windows.Forms.Button();
            this.labelFriendsToInvite = new System.Windows.Forms.Label();
            this.labelPartyInformation = new System.Windows.Forms.Label();
            this.comboBoxSelectedFriendForBirthday = new System.Windows.Forms.ComboBox();
            this.textBoxPartyInformation = new System.Windows.Forms.RichTextBox();
            this.dataGridFriendsToInvite = new System.Windows.Forms.DataGridView();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnAddToParty = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.buttonSelectFriendBirthday = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelSelectFriendBirthday = new System.Windows.Forms.Label();
            this.tabPageFindMatch = new System.Windows.Forms.TabPage();
            this.dataGridViewMatches = new System.Windows.Forms.DataGridView();
            this.userColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenderColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.onlineStatusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSubscribers = new System.Windows.Forms.Button();
            this.labelChooseGender = new System.Windows.Forms.Label();
            this.labelSearch = new System.Windows.Forms.Label();
            this.MaleCheckBox = new System.Windows.Forms.CheckBox();
            this.FemaleCheckBox = new System.Windows.Forms.CheckBox();
            this.RelationshipComboBox = new System.Windows.Forms.ComboBox();
            this.luckSearchButton = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.tabPageFriends = new System.Windows.Forms.TabPage();
            this.buttonRefreshFriends = new System.Windows.Forms.Button();
            this.labelOfflineFriends = new System.Windows.Forms.Label();
            this.labelActiveFriends = new System.Windows.Forms.Label();
            this.labelAllFriends = new System.Windows.Forms.Label();
            this.listBoxOfflineFriends = new System.Windows.Forms.ListBox();
            this.listBoxActiveFriends = new System.Windows.Forms.ListBox();
            this.listBoxAllFriends = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPageHomePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEvent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.tabPagePlanBirthdayParty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFriendsToInvite)).BeginInit();
            this.tabPageFindMatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatches)).BeginInit();
            this.tabPageFriends.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageHomePage);
            this.tabControl1.Controls.Add(this.tabPagePlanBirthdayParty);
            this.tabControl1.Controls.Add(this.tabPageFindMatch);
            this.tabControl1.Controls.Add(this.tabPageFriends);
            this.tabControl1.Location = new System.Drawing.Point(0, -2);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1127, 816);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageHomePage
            // 
            this.tabPageHomePage.BackColor = System.Drawing.Color.AliceBlue;
            this.tabPageHomePage.Controls.Add(this.listBoxComments);
            this.tabPageHomePage.Controls.Add(this.listBoxPosts);
            this.tabPageHomePage.Controls.Add(this.listBoxEvents);
            this.tabPageHomePage.Controls.Add(this.listBoxGroups);
            this.tabPageHomePage.Controls.Add(this.buttonFetchEvents);
            this.tabPageHomePage.Controls.Add(this.buttonFetchGroups);
            this.tabPageHomePage.Controls.Add(this.pictureBoxEvent);
            this.tabPageHomePage.Controls.Add(this.pictureBoxGroup);
            this.tabPageHomePage.Controls.Add(this.pictureBoxAlbum);
            this.tabPageHomePage.Controls.Add(this.listBoxAlbums);
            this.tabPageHomePage.Controls.Add(this.buttonFetchAlbums);
            this.tabPageHomePage.Controls.Add(this.buttonFetchPosts);
            this.tabPageHomePage.Controls.Add(this.labelComments);
            this.tabPageHomePage.Controls.Add(this.pictureBoxProfile);
            this.tabPageHomePage.Controls.Add(this.label1);
            this.tabPageHomePage.Controls.Add(this.buttonResetTextBox);
            this.tabPageHomePage.Controls.Add(this.buttonPostStatus);
            this.tabPageHomePage.Controls.Add(this.textBoxStatus);
            this.tabPageHomePage.Controls.Add(this.buttonLogout);
            this.tabPageHomePage.Controls.Add(this.buttonLogin);
            this.tabPageHomePage.Location = new System.Drawing.Point(4, 25);
            this.tabPageHomePage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageHomePage.Name = "tabPageHomePage";
            this.tabPageHomePage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageHomePage.Size = new System.Drawing.Size(1119, 787);
            this.tabPageHomePage.TabIndex = 0;
            this.tabPageHomePage.Text = "Home Page";
            // 
            // listBoxComments
            // 
            this.listBoxComments.FormattingEnabled = true;
            this.listBoxComments.ItemHeight = 16;
            this.listBoxComments.Location = new System.Drawing.Point(723, 263);
            this.listBoxComments.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxComments.Name = "listBoxComments";
            this.listBoxComments.Size = new System.Drawing.Size(260, 164);
            this.listBoxComments.TabIndex = 93;
            // 
            // listBoxPosts
            // 
            this.listBoxPosts.FormattingEnabled = true;
            this.listBoxPosts.ItemHeight = 16;
            this.listBoxPosts.Location = new System.Drawing.Point(32, 263);
            this.listBoxPosts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxPosts.Name = "listBoxPosts";
            this.listBoxPosts.Size = new System.Drawing.Size(633, 164);
            this.listBoxPosts.TabIndex = 92;
            this.listBoxPosts.SelectedIndexChanged += new System.EventHandler(this.listBoxPosts_SelectedIndexChanged);
            // 
            // listBoxEvents
            // 
            this.listBoxEvents.FormattingEnabled = true;
            this.listBoxEvents.ItemHeight = 16;
            this.listBoxEvents.Location = new System.Drawing.Point(748, 517);
            this.listBoxEvents.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxEvents.Name = "listBoxEvents";
            this.listBoxEvents.Size = new System.Drawing.Size(208, 244);
            this.listBoxEvents.TabIndex = 91;
            this.listBoxEvents.SelectedIndexChanged += new System.EventHandler(this.listBoxEvents_SelectedIndexChanged);
            // 
            // listBoxGroups
            // 
            this.listBoxGroups.FormattingEnabled = true;
            this.listBoxGroups.ItemHeight = 16;
            this.listBoxGroups.Location = new System.Drawing.Point(379, 518);
            this.listBoxGroups.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxGroups.Name = "listBoxGroups";
            this.listBoxGroups.Size = new System.Drawing.Size(219, 244);
            this.listBoxGroups.TabIndex = 90;
            this.listBoxGroups.SelectedIndexChanged += new System.EventHandler(this.listBoxGroups_SelectedIndexChanged);
            // 
            // buttonFetchEvents
            // 
            this.buttonFetchEvents.Location = new System.Drawing.Point(748, 482);
            this.buttonFetchEvents.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonFetchEvents.Name = "buttonFetchEvents";
            this.buttonFetchEvents.Size = new System.Drawing.Size(128, 28);
            this.buttonFetchEvents.TabIndex = 89;
            this.buttonFetchEvents.Text = "Fetch Events";
            this.buttonFetchEvents.UseVisualStyleBackColor = true;
            this.buttonFetchEvents.Click += new System.EventHandler(this.buttonFetchEvents_Click);
            // 
            // buttonFetchGroups
            // 
            this.buttonFetchGroups.Location = new System.Drawing.Point(379, 481);
            this.buttonFetchGroups.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonFetchGroups.Name = "buttonFetchGroups";
            this.buttonFetchGroups.Size = new System.Drawing.Size(116, 28);
            this.buttonFetchGroups.TabIndex = 88;
            this.buttonFetchGroups.Text = "Fetch Groups";
            this.buttonFetchGroups.UseVisualStyleBackColor = true;
            this.buttonFetchGroups.Click += new System.EventHandler(this.buttonFetchGroups_Click);
            // 
            // pictureBoxEvent
            // 
            this.pictureBoxEvent.BackColor = System.Drawing.Color.LightBlue;
            this.pictureBoxEvent.Location = new System.Drawing.Point(965, 518);
            this.pictureBoxEvent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBoxEvent.Name = "pictureBoxEvent";
            this.pictureBoxEvent.Size = new System.Drawing.Size(133, 102);
            this.pictureBoxEvent.TabIndex = 87;
            this.pictureBoxEvent.TabStop = false;
            // 
            // pictureBoxGroup
            // 
            this.pictureBoxGroup.BackColor = System.Drawing.Color.LightBlue;
            this.pictureBoxGroup.Location = new System.Drawing.Point(607, 517);
            this.pictureBoxGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBoxGroup.Name = "pictureBoxGroup";
            this.pictureBoxGroup.Size = new System.Drawing.Size(133, 102);
            this.pictureBoxGroup.TabIndex = 86;
            this.pictureBoxGroup.TabStop = false;
            // 
            // pictureBoxAlbum
            // 
            this.pictureBoxAlbum.BackColor = System.Drawing.Color.LightBlue;
            this.pictureBoxAlbum.Location = new System.Drawing.Point(249, 517);
            this.pictureBoxAlbum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBoxAlbum.Name = "pictureBoxAlbum";
            this.pictureBoxAlbum.Size = new System.Drawing.Size(121, 103);
            this.pictureBoxAlbum.TabIndex = 85;
            this.pictureBoxAlbum.TabStop = false;
            // 
            // listBoxAlbums
            // 
            this.listBoxAlbums.FormattingEnabled = true;
            this.listBoxAlbums.ItemHeight = 16;
            this.listBoxAlbums.Location = new System.Drawing.Point(32, 518);
            this.listBoxAlbums.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxAlbums.Name = "listBoxAlbums";
            this.listBoxAlbums.Size = new System.Drawing.Size(208, 244);
            this.listBoxAlbums.TabIndex = 84;
            this.listBoxAlbums.SelectedIndexChanged += new System.EventHandler(this.listBoxAlbums_SelectedIndexChanged);
            // 
            // buttonFetchAlbums
            // 
            this.buttonFetchAlbums.Location = new System.Drawing.Point(32, 482);
            this.buttonFetchAlbums.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonFetchAlbums.Name = "buttonFetchAlbums";
            this.buttonFetchAlbums.Size = new System.Drawing.Size(115, 28);
            this.buttonFetchAlbums.TabIndex = 83;
            this.buttonFetchAlbums.Text = "Fetch Albums";
            this.buttonFetchAlbums.UseVisualStyleBackColor = true;
            this.buttonFetchAlbums.Click += new System.EventHandler(this.buttonFetchAlbums_Click);
            // 
            // buttonFetchPosts
            // 
            this.buttonFetchPosts.Location = new System.Drawing.Point(32, 229);
            this.buttonFetchPosts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonFetchPosts.Name = "buttonFetchPosts";
            this.buttonFetchPosts.Size = new System.Drawing.Size(100, 28);
            this.buttonFetchPosts.TabIndex = 82;
            this.buttonFetchPosts.Text = "Fetch Posts";
            this.buttonFetchPosts.UseVisualStyleBackColor = true;
            this.buttonFetchPosts.Click += new System.EventHandler(this.buttonFetchPosts_Click);
            // 
            // labelComments
            // 
            this.labelComments.AutoSize = true;
            this.labelComments.Location = new System.Drawing.Point(719, 240);
            this.labelComments.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelComments.Name = "labelComments";
            this.labelComments.Size = new System.Drawing.Size(74, 17);
            this.labelComments.TabIndex = 81;
            this.labelComments.Text = "Comments";
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.BackColor = System.Drawing.Color.LightBlue;
            this.pictureBoxProfile.Location = new System.Drawing.Point(32, 92);
            this.pictureBoxProfile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(152, 118);
            this.pictureBoxProfile.TabIndex = 78;
            this.pictureBoxProfile.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(297, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 17);
            this.label1.TabIndex = 77;
            this.label1.Text = "Share your thoughts :";
            // 
            // buttonResetTextBox
            // 
            this.buttonResetTextBox.Location = new System.Drawing.Point(776, 182);
            this.buttonResetTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonResetTextBox.Name = "buttonResetTextBox";
            this.buttonResetTextBox.Size = new System.Drawing.Size(100, 28);
            this.buttonResetTextBox.TabIndex = 76;
            this.buttonResetTextBox.Text = "Reset";
            this.buttonResetTextBox.UseVisualStyleBackColor = true;
            this.buttonResetTextBox.Click += new System.EventHandler(this.buttonResetTextBox_Click);
            // 
            // buttonPostStatus
            // 
            this.buttonPostStatus.Location = new System.Drawing.Point(884, 182);
            this.buttonPostStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonPostStatus.Name = "buttonPostStatus";
            this.buttonPostStatus.Size = new System.Drawing.Size(100, 28);
            this.buttonPostStatus.TabIndex = 75;
            this.buttonPostStatus.Text = "Post Status";
            this.buttonPostStatus.UseVisualStyleBackColor = true;
            this.buttonPostStatus.Click += new System.EventHandler(this.buttonPostStatus_Click);
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Location = new System.Drawing.Point(301, 57);
            this.textBoxStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(681, 117);
            this.textBoxStatus.TabIndex = 74;
            this.textBoxStatus.Text = "";
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(16, 57);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(239, 28);
            this.buttonLogout.TabIndex = 73;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(16, 21);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(239, 28);
            this.buttonLogin.TabIndex = 72;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // tabPagePlanBirthdayParty
            // 
            this.tabPagePlanBirthdayParty.BackColor = System.Drawing.Color.Lavender;
            this.tabPagePlanBirthdayParty.Controls.Add(this.textBoxPartyLocation);
            this.tabPagePlanBirthdayParty.Controls.Add(this.labelPartyLocation);
            this.tabPagePlanBirthdayParty.Controls.Add(this.labelPartyDate);
            this.tabPagePlanBirthdayParty.Controls.Add(this.dateTimePickerPartyDate);
            this.tabPagePlanBirthdayParty.Controls.Add(this.textBoxViewBirthdayIn);
            this.tabPagePlanBirthdayParty.Controls.Add(this.labelDays);
            this.tabPagePlanBirthdayParty.Controls.Add(this.buttonCreateBirthdayParty);
            this.tabPagePlanBirthdayParty.Controls.Add(this.labelFriendsToInvite);
            this.tabPagePlanBirthdayParty.Controls.Add(this.labelPartyInformation);
            this.tabPagePlanBirthdayParty.Controls.Add(this.comboBoxSelectedFriendForBirthday);
            this.tabPagePlanBirthdayParty.Controls.Add(this.textBoxPartyInformation);
            this.tabPagePlanBirthdayParty.Controls.Add(this.dataGridFriendsToInvite);
            this.tabPagePlanBirthdayParty.Controls.Add(this.buttonSelectFriendBirthday);
            this.tabPagePlanBirthdayParty.Controls.Add(this.label2);
            this.tabPagePlanBirthdayParty.Controls.Add(this.labelSelectFriendBirthday);
            this.tabPagePlanBirthdayParty.Location = new System.Drawing.Point(4, 25);
            this.tabPagePlanBirthdayParty.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPagePlanBirthdayParty.Name = "tabPagePlanBirthdayParty";
            this.tabPagePlanBirthdayParty.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPagePlanBirthdayParty.Size = new System.Drawing.Size(1119, 787);
            this.tabPagePlanBirthdayParty.TabIndex = 1;
            this.tabPagePlanBirthdayParty.Text = "Birthdays Planning";
            // 
            // textBoxPartyLocation
            // 
            this.textBoxPartyLocation.Location = new System.Drawing.Point(797, 49);
            this.textBoxPartyLocation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPartyLocation.Name = "textBoxPartyLocation";
            this.textBoxPartyLocation.Size = new System.Drawing.Size(249, 22);
            this.textBoxPartyLocation.TabIndex = 19;
            // 
            // labelPartyLocation
            // 
            this.labelPartyLocation.AutoSize = true;
            this.labelPartyLocation.Location = new System.Drawing.Point(615, 49);
            this.labelPartyLocation.Name = "labelPartyLocation";
            this.labelPartyLocation.Size = new System.Drawing.Size(159, 17);
            this.labelPartyLocation.TabIndex = 18;
            this.labelPartyLocation.Text = "Choose party\'s location:";
            // 
            // labelPartyDate
            // 
            this.labelPartyDate.AutoSize = true;
            this.labelPartyDate.Location = new System.Drawing.Point(615, 17);
            this.labelPartyDate.Name = "labelPartyDate";
            this.labelPartyDate.Size = new System.Drawing.Size(138, 17);
            this.labelPartyDate.TabIndex = 17;
            this.labelPartyDate.Text = "Choose party\'s date:";
            // 
            // dateTimePickerPartyDate
            // 
            this.dateTimePickerPartyDate.Location = new System.Drawing.Point(797, 17);
            this.dateTimePickerPartyDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerPartyDate.MinDate = new System.DateTime(2021, 11, 9, 16, 12, 56, 524);
            this.dateTimePickerPartyDate.Name = "dateTimePickerPartyDate";
            this.dateTimePickerPartyDate.Size = new System.Drawing.Size(249, 22);
            this.dateTimePickerPartyDate.TabIndex = 16;
            // 
            // textBoxViewBirthdayIn
            // 
            this.textBoxViewBirthdayIn.Location = new System.Drawing.Point(320, 14);
            this.textBoxViewBirthdayIn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxViewBirthdayIn.Name = "textBoxViewBirthdayIn";
            this.textBoxViewBirthdayIn.Size = new System.Drawing.Size(113, 22);
            this.textBoxViewBirthdayIn.TabIndex = 15;
            // 
            // labelDays
            // 
            this.labelDays.AutoSize = true;
            this.labelDays.Location = new System.Drawing.Point(440, 17);
            this.labelDays.Name = "labelDays";
            this.labelDays.Size = new System.Drawing.Size(40, 17);
            this.labelDays.TabIndex = 14;
            this.labelDays.Text = "Days";
            // 
            // buttonCreateBirthdayParty
            // 
            this.buttonCreateBirthdayParty.Location = new System.Drawing.Point(879, 683);
            this.buttonCreateBirthdayParty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCreateBirthdayParty.Name = "buttonCreateBirthdayParty";
            this.buttonCreateBirthdayParty.Size = new System.Drawing.Size(185, 32);
            this.buttonCreateBirthdayParty.TabIndex = 13;
            this.buttonCreateBirthdayParty.Text = "Create Birthday Party!";
            this.buttonCreateBirthdayParty.UseVisualStyleBackColor = true;
            this.buttonCreateBirthdayParty.Click += new System.EventHandler(this.buttonCreateBirthdayParty_Click);
            // 
            // labelFriendsToInvite
            // 
            this.labelFriendsToInvite.AutoSize = true;
            this.labelFriendsToInvite.Location = new System.Drawing.Point(32, 271);
            this.labelFriendsToInvite.Name = "labelFriendsToInvite";
            this.labelFriendsToInvite.Size = new System.Drawing.Size(267, 17);
            this.labelFriendsToInvite.TabIndex = 12;
            this.labelFriendsToInvite.Text = "Check the friends you would like to invite:";
            // 
            // labelPartyInformation
            // 
            this.labelPartyInformation.AutoSize = true;
            this.labelPartyInformation.Location = new System.Drawing.Point(32, 70);
            this.labelPartyInformation.Name = "labelPartyInformation";
            this.labelPartyInformation.Size = new System.Drawing.Size(224, 17);
            this.labelPartyInformation.TabIndex = 11;
            this.labelPartyInformation.Text = "Party information and desctiprtion:";
            // 
            // comboBoxSelectedFriendForBirthday
            // 
            this.comboBoxSelectedFriendForBirthday.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectedFriendForBirthday.FormattingEnabled = true;
            this.comboBoxSelectedFriendForBirthday.Location = new System.Drawing.Point(152, 42);
            this.comboBoxSelectedFriendForBirthday.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxSelectedFriendForBirthday.Name = "comboBoxSelectedFriendForBirthday";
            this.comboBoxSelectedFriendForBirthday.Size = new System.Drawing.Size(409, 24);
            this.comboBoxSelectedFriendForBirthday.TabIndex = 10;
            this.comboBoxSelectedFriendForBirthday.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectedFriendForBirthday_SelectedIndexChanged);
            // 
            // textBoxPartyInformation
            // 
            this.textBoxPartyInformation.Location = new System.Drawing.Point(32, 97);
            this.textBoxPartyInformation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPartyInformation.Name = "textBoxPartyInformation";
            this.textBoxPartyInformation.Size = new System.Drawing.Size(1015, 157);
            this.textBoxPartyInformation.TabIndex = 9;
            this.textBoxPartyInformation.Text = "";
            // 
            // dataGridFriendsToInvite
            // 
            this.dataGridFriendsToInvite.AllowUserToAddRows = false;
            this.dataGridFriendsToInvite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridFriendsToInvite.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridFriendsToInvite.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridFriendsToInvite.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFriendsToInvite.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnName,
            this.columnAddToParty});
            this.dataGridFriendsToInvite.Location = new System.Drawing.Point(32, 302);
            this.dataGridFriendsToInvite.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridFriendsToInvite.Name = "dataGridFriendsToInvite";
            this.dataGridFriendsToInvite.RowHeadersWidth = 82;
            this.dataGridFriendsToInvite.RowTemplate.Height = 33;
            this.dataGridFriendsToInvite.Size = new System.Drawing.Size(1015, 377);
            this.dataGridFriendsToInvite.TabIndex = 8;
            // 
            // columnName
            // 
            this.columnName.FillWeight = 400F;
            this.columnName.HeaderText = "Name";
            this.columnName.MinimumWidth = 10;
            this.columnName.Name = "columnName";
            this.columnName.ReadOnly = true;
            // 
            // columnAddToParty
            // 
            this.columnAddToParty.HeaderText = "Add to party";
            this.columnAddToParty.MinimumWidth = 10;
            this.columnAddToParty.Name = "columnAddToParty";
            this.columnAddToParty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnAddToParty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // buttonSelectFriendBirthday
            // 
            this.buttonSelectFriendBirthday.Location = new System.Drawing.Point(485, 14);
            this.buttonSelectFriendBirthday.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSelectFriendBirthday.Name = "buttonSelectFriendBirthday";
            this.buttonSelectFriendBirthday.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectFriendBirthday.TabIndex = 5;
            this.buttonSelectFriendBirthday.Text = "Select";
            this.buttonSelectFriendBirthday.UseVisualStyleBackColor = true;
            this.buttonSelectFriendBirthday.Click += new System.EventHandler(this.buttonSelectFriendBirthday_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(292, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Show friends that have a birthday in the next:";
            // 
            // labelSelectFriendBirthday
            // 
            this.labelSelectFriendBirthday.AutoSize = true;
            this.labelSelectFriendBirthday.Location = new System.Drawing.Point(29, 46);
            this.labelSelectFriendBirthday.Name = "labelSelectFriendBirthday";
            this.labelSelectFriendBirthday.Size = new System.Drawing.Size(103, 17);
            this.labelSelectFriendBirthday.TabIndex = 0;
            this.labelSelectFriendBirthday.Text = "Select a friend:";
            // 
            // tabPageFindMatch
            // 
            this.tabPageFindMatch.BackColor = System.Drawing.Color.Lavender;
            this.tabPageFindMatch.Controls.Add(this.dataGridViewMatches);
            this.tabPageFindMatch.Controls.Add(this.buttonSubscribers);
            this.tabPageFindMatch.Controls.Add(this.labelChooseGender);
            this.tabPageFindMatch.Controls.Add(this.labelSearch);
            this.tabPageFindMatch.Controls.Add(this.MaleCheckBox);
            this.tabPageFindMatch.Controls.Add(this.FemaleCheckBox);
            this.tabPageFindMatch.Controls.Add(this.RelationshipComboBox);
            this.tabPageFindMatch.Controls.Add(this.luckSearchButton);
            this.tabPageFindMatch.Controls.Add(this.buttonSearch);
            this.tabPageFindMatch.Location = new System.Drawing.Point(4, 25);
            this.tabPageFindMatch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageFindMatch.Name = "tabPageFindMatch";
            this.tabPageFindMatch.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageFindMatch.Size = new System.Drawing.Size(1119, 787);
            this.tabPageFindMatch.TabIndex = 2;
            this.tabPageFindMatch.Text = "Find a match";
            // 
            // dataGridViewMatches
            // 
            this.dataGridViewMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMatches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userColumn,
            this.NameColumn,
            this.GenderColumn,
            this.ageColumn,
            this.statusColumn,
            this.onlineStatusColumn});
            this.dataGridViewMatches.Location = new System.Drawing.Point(327, 122);
            this.dataGridViewMatches.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewMatches.Name = "dataGridViewMatches";
            this.dataGridViewMatches.RowHeadersWidth = 51;
            this.dataGridViewMatches.Size = new System.Drawing.Size(724, 588);
            this.dataGridViewMatches.TabIndex = 10;
            // 
            // userColumn
            // 
            this.userColumn.HeaderText = "hiddenUserColumn";
            this.userColumn.MinimumWidth = 6;
            this.userColumn.Name = "userColumn";
            this.userColumn.Visible = false;
            this.userColumn.Width = 125;
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.MinimumWidth = 6;
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.Width = 125;
            // 
            // GenderColumn
            // 
            this.GenderColumn.HeaderText = "Gender";
            this.GenderColumn.MinimumWidth = 6;
            this.GenderColumn.Name = "GenderColumn";
            this.GenderColumn.Width = 125;
            // 
            // ageColumn
            // 
            this.ageColumn.HeaderText = "Location";
            this.ageColumn.MinimumWidth = 6;
            this.ageColumn.Name = "ageColumn";
            this.ageColumn.Width = 125;
            // 
            // statusColumn
            // 
            this.statusColumn.HeaderText = "Relationship Status";
            this.statusColumn.MinimumWidth = 6;
            this.statusColumn.Name = "statusColumn";
            this.statusColumn.Width = 125;
            // 
            // onlineStatusColumn
            // 
            this.onlineStatusColumn.HeaderText = "Online Status";
            this.onlineStatusColumn.MinimumWidth = 6;
            this.onlineStatusColumn.Name = "onlineStatusColumn";
            this.onlineStatusColumn.Width = 125;
            // 
            // buttonSubscribers
            // 
            this.buttonSubscribers.Location = new System.Drawing.Point(12, 220);
            this.buttonSubscribers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSubscribers.Name = "buttonSubscribers";
            this.buttonSubscribers.Size = new System.Drawing.Size(307, 97);
            this.buttonSubscribers.TabIndex = 9;
            this.buttonSubscribers.Text = "My subscribers";
            this.buttonSubscribers.UseVisualStyleBackColor = true;
            this.buttonSubscribers.Click += new System.EventHandler(this.buttonSubscribers_Click);
            // 
            // labelChooseGender
            // 
            this.labelChooseGender.AutoSize = true;
            this.labelChooseGender.Location = new System.Drawing.Point(816, 71);
            this.labelChooseGender.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelChooseGender.Name = "labelChooseGender";
            this.labelChooseGender.Size = new System.Drawing.Size(153, 17);
            this.labelChooseGender.TabIndex = 7;
            this.labelChooseGender.Text = "Check what you prefer:";
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(816, 22);
            this.labelSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(163, 17);
            this.labelSearch.TabIndex = 6;
            this.labelSearch.Text = "What you searching for?";
            // 
            // MaleCheckBox
            // 
            this.MaleCheckBox.AutoSize = true;
            this.MaleCheckBox.Location = new System.Drawing.Point(820, 91);
            this.MaleCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaleCheckBox.Name = "MaleCheckBox";
            this.MaleCheckBox.Size = new System.Drawing.Size(60, 21);
            this.MaleCheckBox.TabIndex = 5;
            this.MaleCheckBox.Text = "Male";
            this.MaleCheckBox.UseVisualStyleBackColor = true;
            // 
            // FemaleCheckBox
            // 
            this.FemaleCheckBox.AutoSize = true;
            this.FemaleCheckBox.Location = new System.Drawing.Point(927, 91);
            this.FemaleCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FemaleCheckBox.Name = "FemaleCheckBox";
            this.FemaleCheckBox.Size = new System.Drawing.Size(76, 21);
            this.FemaleCheckBox.TabIndex = 4;
            this.FemaleCheckBox.Text = "Female";
            this.FemaleCheckBox.UseVisualStyleBackColor = true;
            // 
            // RelationshipComboBox
            // 
            this.RelationshipComboBox.FormattingEnabled = true;
            this.RelationshipComboBox.Items.AddRange(new object[] {
            "All",
            "Single",
            "Divorced",
            "In open relationship"});
            this.RelationshipComboBox.Location = new System.Drawing.Point(820, 42);
            this.RelationshipComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RelationshipComboBox.Name = "RelationshipComboBox";
            this.RelationshipComboBox.Size = new System.Drawing.Size(229, 24);
            this.RelationshipComboBox.TabIndex = 3;
            // 
            // luckSearchButton
            // 
            this.luckSearchButton.Location = new System.Drawing.Point(11, 121);
            this.luckSearchButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.luckSearchButton.Name = "luckSearchButton";
            this.luckSearchButton.Size = new System.Drawing.Size(308, 92);
            this.luckSearchButton.TabIndex = 2;
            this.luckSearchButton.Text = "More Luck then brains";
            this.luckSearchButton.UseVisualStyleBackColor = true;
            this.luckSearchButton.Click += new System.EventHandler(this.buttonLuckSearch_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(327, 7);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(467, 106);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // tabPageFriends
            // 
            this.tabPageFriends.BackColor = System.Drawing.Color.Lavender;
            this.tabPageFriends.Controls.Add(this.buttonRefreshFriends);
            this.tabPageFriends.Controls.Add(this.labelOfflineFriends);
            this.tabPageFriends.Controls.Add(this.labelActiveFriends);
            this.tabPageFriends.Controls.Add(this.labelAllFriends);
            this.tabPageFriends.Controls.Add(this.listBoxOfflineFriends);
            this.tabPageFriends.Controls.Add(this.listBoxActiveFriends);
            this.tabPageFriends.Controls.Add(this.listBoxAllFriends);
            this.tabPageFriends.Location = new System.Drawing.Point(4, 25);
            this.tabPageFriends.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageFriends.Name = "tabPageFriends";
            this.tabPageFriends.Size = new System.Drawing.Size(1119, 787);
            this.tabPageFriends.TabIndex = 3;
            this.tabPageFriends.Text = "Friends";
            // 
            // buttonRefreshFriends
            // 
            this.buttonRefreshFriends.Location = new System.Drawing.Point(948, 4);
            this.buttonRefreshFriends.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRefreshFriends.Name = "buttonRefreshFriends";
            this.buttonRefreshFriends.Size = new System.Drawing.Size(164, 47);
            this.buttonRefreshFriends.TabIndex = 6;
            this.buttonRefreshFriends.Text = "Refresh";
            this.buttonRefreshFriends.UseVisualStyleBackColor = true;
            this.buttonRefreshFriends.Click += new System.EventHandler(this.buttonRefreshFriends_Click);
            // 
            // labelOfflineFriends
            // 
            this.labelOfflineFriends.AutoSize = true;
            this.labelOfflineFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOfflineFriends.Location = new System.Drawing.Point(752, 31);
            this.labelOfflineFriends.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOfflineFriends.Name = "labelOfflineFriends";
            this.labelOfflineFriends.Size = new System.Drawing.Size(134, 20);
            this.labelOfflineFriends.TabIndex = 5;
            this.labelOfflineFriends.Text = "Offline Friends";
            // 
            // labelActiveFriends
            // 
            this.labelActiveFriends.AutoSize = true;
            this.labelActiveFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActiveFriends.Location = new System.Drawing.Point(372, 31);
            this.labelActiveFriends.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelActiveFriends.Name = "labelActiveFriends";
            this.labelActiveFriends.Size = new System.Drawing.Size(130, 20);
            this.labelActiveFriends.TabIndex = 4;
            this.labelActiveFriends.Text = "Active Friends";
            // 
            // labelAllFriends
            // 
            this.labelAllFriends.AutoSize = true;
            this.labelAllFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAllFriends.Location = new System.Drawing.Point(27, 31);
            this.labelAllFriends.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAllFriends.Name = "labelAllFriends";
            this.labelAllFriends.Size = new System.Drawing.Size(101, 20);
            this.labelAllFriends.TabIndex = 3;
            this.labelAllFriends.Text = "All friends:";
            // 
            // listBoxOfflineFriends
            // 
            this.listBoxOfflineFriends.FormattingEnabled = true;
            this.listBoxOfflineFriends.ItemHeight = 16;
            this.listBoxOfflineFriends.Location = new System.Drawing.Point(756, 68);
            this.listBoxOfflineFriends.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxOfflineFriends.Name = "listBoxOfflineFriends";
            this.listBoxOfflineFriends.Size = new System.Drawing.Size(317, 596);
            this.listBoxOfflineFriends.TabIndex = 2;
            // 
            // listBoxActiveFriends
            // 
            this.listBoxActiveFriends.FormattingEnabled = true;
            this.listBoxActiveFriends.ItemHeight = 16;
            this.listBoxActiveFriends.Location = new System.Drawing.Point(376, 68);
            this.listBoxActiveFriends.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxActiveFriends.Name = "listBoxActiveFriends";
            this.listBoxActiveFriends.Size = new System.Drawing.Size(327, 596);
            this.listBoxActiveFriends.TabIndex = 1;
            // 
            // listBoxAllFriends
            // 
            this.listBoxAllFriends.FormattingEnabled = true;
            this.listBoxAllFriends.ItemHeight = 16;
            this.listBoxAllFriends.Location = new System.Drawing.Point(31, 68);
            this.listBoxAllFriends.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxAllFriends.Name = "listBoxAllFriends";
            this.listBoxAllFriends.Size = new System.Drawing.Size(300, 596);
            this.listBoxAllFriends.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 750);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPageHomePage.ResumeLayout(false);
            this.tabPageHomePage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEvent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.tabPagePlanBirthdayParty.ResumeLayout(false);
            this.tabPagePlanBirthdayParty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFriendsToInvite)).EndInit();
            this.tabPageFindMatch.ResumeLayout(false);
            this.tabPageFindMatch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatches)).EndInit();
            this.tabPageFriends.ResumeLayout(false);
            this.tabPageFriends.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageHomePage;
        private System.Windows.Forms.ListBox listBoxEvents;
        private System.Windows.Forms.ListBox listBoxGroups;
        private System.Windows.Forms.Button buttonFetchEvents;
        private System.Windows.Forms.Button buttonFetchGroups;
        private System.Windows.Forms.PictureBox pictureBoxEvent;
        private System.Windows.Forms.PictureBox pictureBoxGroup;
        private System.Windows.Forms.PictureBox pictureBoxAlbum;
        private System.Windows.Forms.ListBox listBoxAlbums;
        private System.Windows.Forms.Button buttonFetchAlbums;
        private System.Windows.Forms.Button buttonFetchPosts;
        private System.Windows.Forms.Label labelComments;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonResetTextBox;
        private System.Windows.Forms.Button buttonPostStatus;
        private System.Windows.Forms.RichTextBox textBoxStatus;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TabPage tabPagePlanBirthdayParty;
        private System.Windows.Forms.TabPage tabPageFindMatch;
        private System.Windows.Forms.ListBox listBoxPosts;
        private System.Windows.Forms.ListBox listBoxComments;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelSelectFriendBirthday;
        private Button buttonSelectFriendBirthday;
        private Label labelPartyInformation;
        private ComboBox comboBoxSelectedFriendForBirthday;
        private RichTextBox textBoxPartyInformation;
        private Button buttonCreateBirthdayParty;
        private Label labelFriendsToInvite;
        private Label labelDays;
        private TextBox textBoxViewBirthdayIn;
        private DataGridView dataGridFriendsToInvite;
        private DataGridViewTextBoxColumn columnName;
        private DataGridViewCheckBoxColumn columnAddToParty;
        private Label labelPartyLocation;
        private Label labelPartyDate;
        private DateTimePicker dateTimePickerPartyDate;
        private TextBox textBoxPartyLocation;
        private Label labelChooseGender;
        private Label labelSearch;
        private CheckBox MaleCheckBox;
        private CheckBox FemaleCheckBox;
        private ComboBox RelationshipComboBox;
        private Button luckSearchButton;
        private Button buttonSearch;
        private Button buttonSubscribers;
        private DataGridView dataGridViewMatches;
        private DataGridViewTextBoxColumn userColumn;
        private DataGridViewTextBoxColumn NameColumn;
        private DataGridViewTextBoxColumn GenderColumn;
        private DataGridViewTextBoxColumn ageColumn;
        private DataGridViewTextBoxColumn statusColumn;
        private DataGridViewTextBoxColumn onlineStatusColumn;
        private TabPage tabPageFriends;
        private Label labelOfflineFriends;
        private Label labelActiveFriends;
        private Label labelAllFriends;
        private ListBox listBoxOfflineFriends;
        private ListBox listBoxActiveFriends;
        private ListBox listBoxAllFriends;
        private Button buttonRefreshFriends;
    }
}

