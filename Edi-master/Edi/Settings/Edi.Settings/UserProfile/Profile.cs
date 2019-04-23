﻿namespace Edi.Settings.UserProfile
{
    using Edi.Settings.Interfaces;
    using FileSystemModels.Models;
    using MRULib.MRU.Models.Persist;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// This class implements the model of the user profile part
    /// of the application. Typically, users have implicit run-time
    /// settings that should be re-activated when the application
    /// is re-started at a later point in time (e.g. window size
    /// and position).
    /// 
    /// This class organizes these per user specific profile settings
    /// and is responsible for their storage (at program end) and
    /// retrieval at the start-up of the application.
    /// </summary>
    public class Profile : IProfile
    {
        #region fields
        private MRUList _MruList;

        private List<string> mFindHistoryList;
        private List<string> mReplaceHistoryList;

        protected static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion fields

        #region constructor
        /// <summary>
        /// Class constructor
        /// </summary>
        public Profile()
        {
            // Set default session data
            this.MainWindowPosSz = new ViewPosSizeModel(100, 100, 1000, 700);

            this.IsWorkspaceAreaOptimized = false;

            this.LastActiveFile = string.Empty;

            _MruList = new MRUList();
        }
        #endregion constructor

        #region properties
        /// <summary>
        /// Get/set position and size of MainWindow
        /// </summary>
        [XmlElement(ElementName = "MainWindowPos")]
        public ViewPosSizeModel MainWindowPosSz { get; set; }

        /// <summary>
        /// Gets/sets whether the workspace area is optimized or not.
        /// The optimized workspace is distructive free and does not
        /// show optional stuff like toolbar and status bar.
        /// </summary>
        [XmlAttribute(AttributeName = "IsWorkspaceAreaOptimized")]
        public bool IsWorkspaceAreaOptimized { get; set; }

        /// <summary>
        /// Remember the last active path and name of last active document.
        /// 
        /// This can be useful when selecting active document in next session or
        /// determining a useful default path when there is no document currently open.
        /// </summary>
        [XmlAttribute(AttributeName = "LastActiveFile")]
        public string LastActiveFile { get; set; }

        /// <summary>
        /// List of most recently used files
        /// </summary>
        public MRUList MruList
        {
            get
            {
                if (this._MruList == null)
                    this._MruList = new MRUList();

                return this._MruList;
            }

            set
            {
                if (this._MruList != value)
                {
                    this._MruList = value;
                }
            }
        }

        /// <summary>
        /// Get/set settings for explorer tool window.
        /// </summary>
        [XmlElement(ElementName = "LastActiveExplorer")]
        public ExplorerUserProfile LastActiveExplorer { get; set; }

        #region Find and Replace
        /// <summary>
        /// List of find history
        /// </summary>
        /// <returns>list of string</returns>
        public List<string> FindHistoryList
        {
            get
            {
                if (this.mFindHistoryList == null)
                    this.mFindHistoryList = new List<string>();

                return this.mFindHistoryList;
            }

            set
            {
                if (this.mFindHistoryList != value)
                {
                    this.mFindHistoryList = value;
                }
            }
        }

        /// <summary>
        /// List of replace history
        /// </summary>
        /// <returns>list of string</returns>
        public List<string> ReplaceHistoryList
        {
            get
            {
                if (this.mReplaceHistoryList == null)
                    this.mReplaceHistoryList = new List<string>();

                return this.mReplaceHistoryList;
            }

            set
            {
                if (this.mReplaceHistoryList != value)
                {
                    this.mReplaceHistoryList = value;
                }
            }
        }
        #endregion Find and Replace
        #endregion properties

        #region methods
        /// <summary>
        /// Checks if current main window position settings are within
        /// the given bounds or not (and corrects them if not).
        /// </summary>
        /// <param name="SystemParameters_VirtualScreenLeft"></param>
        /// <param name="SystemParameters_VirtualScreenTop"></param>
        public void CheckSettingsOnLoad(double SystemParameters_VirtualScreenLeft,
                                        double SystemParameters_VirtualScreenTop)
        {
            if (this.MainWindowPosSz == null)
                this.MainWindowPosSz = new ViewPosSizeModel(100, 100, 600, 500);

            if (this.MainWindowPosSz.DefaultConstruct == true)
                this.MainWindowPosSz = new ViewPosSizeModel(100, 100, 600, 500);

            this.MainWindowPosSz.SetValidPos(SystemParameters_VirtualScreenLeft,
                                             SystemParameters_VirtualScreenTop);
        }

        /// <summary>
        /// Get the path of the file or empty string if file does not exists on disk.
        /// </summary>
        /// <returns></returns>
        public string GetLastActivePath()
        {
            try
            {
                if (System.IO.File.Exists(this.LastActiveFile))
                    return System.IO.Path.GetDirectoryName(this.LastActiveFile);
            }
            catch
            {
            }

            return string.Empty;
        }
        #endregion methods
    }
}
