using System;
using System.Web.UI.HtmlControls;
using DotNetNuke.Common;
using DotNetNuke.Entities.Host;
using DotNetNuke.UI.Skins;

namespace dng.Dnn.SocialMedia.Skins
{
    public class MetaTags : SkinObjectBase
    {
        #region Public Constructors

        public MetaTags()
        {
            EnableFacebook = true;
            EnableTwitter = true;
        }

        #endregion Public Constructors

        #region Public Properties

        public bool EnableFacebook { get; set; }

        public bool EnableTwitter { get; set; }

        public string FacebookAppId { get; set; }

        public string Sitename { get; set; }

        public string TwitterCard { get; set; }

        #endregion Public Properties

        #region Protected Methods

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            AddFacebookMetaTags();
            AddTwitterMetaTags();
        }

        private void AddFacebookMetaTags()
        {
            if (!EnableFacebook)
                return;

            AddSingleFacebookMetaTag("og:title", PortalSettings.ActiveTab.Title);
            AddSingleFacebookMetaTag("og:description", PortalSettings.ActiveTab.Description);
            AddSingleFacebookMetaTag("og:url", PortalSettings.ActiveTab.FullUrl);

            if (!string.IsNullOrWhiteSpace(PortalSettings.ActiveTab.IconFileLargeRaw))
                AddSingleFacebookMetaTag("og:image", GetImageUrl());

            if (!string.IsNullOrWhiteSpace(Sitename))
                AddSingleFacebookMetaTag("og:site_name", Sitename);

            if (!string.IsNullOrWhiteSpace(FacebookAppId))
                AddSingleFacebookMetaTag("fb:app_id", FacebookAppId);
        }

        /// <summary>
        /// Adds a single Metatag at the end of the html -> head section
        /// </summary>
        /// <param name="name"></param>
        /// <param name="content"></param>
        private void AddMetaTag(
            string name,
            string content)
        {
            Page.Header.Controls.Add(new HtmlMeta()
            {
                Name = name,
                Content = content
            });
        }

        /// <summary>
        /// Adds a single Metatag at the end of the html -> head section
        /// </summary>
        /// <param name="name"></param>
        /// <param name="content"></param>
        private void AddSingleFacebookMetaTag(
            string name,
            string content)
        {
            var metaTag = new HtmlMeta();
            metaTag.Attributes.Add("property", name);
            metaTag.Content = content;

            Page.Header.Controls.Add(metaTag);
        }

        private void AddTwitterMetaTags()
        {
            if (!EnableTwitter)
                return;

            if (!string.IsNullOrWhiteSpace(TwitterCard))
                AddMetaTag("twitter:card", TwitterCard);

            AddMetaTag("twitter:url", PortalSettings.ActiveTab.FullUrl);
            AddMetaTag("twitter:title", PortalSettings.ActiveTab.Title);

            if (!string.IsNullOrWhiteSpace(PortalSettings.ActiveTab.Description))
                AddMetaTag("twitter:description", PortalSettings.ActiveTab.Description);

            if (!string.IsNullOrWhiteSpace(PortalSettings.ActiveTab.IconFileLargeRaw))
                AddMetaTag("twitter:image", GetImageUrl());
        }

        private string GetImageUrl()
        {
            return string.Concat(
                Globals.AddHTTP(Host.HostURL),
                PortalSettings.HomeDirectory,
                PortalSettings.ActiveTab.IconFileLargeRaw);
        }

        #endregion Protected Methods
    }
}