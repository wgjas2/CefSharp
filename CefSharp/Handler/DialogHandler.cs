// Copyright © 2021 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System.Collections.Generic;

namespace CefSharp.Handler
{
    /// <summary>
    /// Implement this interface to handle dialog events. The methods of this class will be called on the CEF UI thread.
    /// </summary>
    public class DialogHandler : IDialogHandler
    {
        /// <inheritdoc/>
        bool IDialogHandler.OnFileDialog(
            IWebBrowser chromiumWebBrowser,
            IBrowser browser,
            CefFileDialogMode mode,
            string title,
            string defaultFilePath,
            IReadOnlyCollection<string> acceptFilters,
            IReadOnlyCollection<string> acceptExtensions,
            IReadOnlyCollection<string> acceptDescriptions,
            IFileDialogCallback callback)
        {
            return OnFileDialog(chromiumWebBrowser, browser, mode, title, defaultFilePath, acceptFilters, acceptExtensions, acceptDescriptions, callback);
        }

        /// <summary>
        /// Runs a file chooser dialog. 
        /// </summary>
        /// <example>
        /// To test assign something like TempFileDialogHandler (from CefSharp.Example) to DialogHandler e.g.
        /// <code>
        /// browser.DialogHandler = new TempFileDialogHandler();
        /// </code>
        /// Example URL to use for file browsing http://www.cs.tut.fi/~jkorpela/forms/file.html#example
        /// Simply click browse, the space next to the browse button should be populated with a randomly generated filename.
        /// </example>
        /// <param name="chromiumWebBrowser">the ChromiumWebBrowser control</param>
        /// <param name="browser">the browser object</param>
        /// <param name="mode">represents the type of dialog to display</param>
        /// <param name="title">the title to be used for the dialog. It may be empty to show the default title ("Open" or "Save" 
        /// depending on the mode).</param>
        /// <param name="defaultFilePath">is the path with optional directory and/or file name component that
        /// should be initially selected in the dialog.</param>
        /// <param name="acceptFilters">are used to restrict the selectable file types and may any combination of
        /// (a) valid lower-cased MIME types (e.g. "text/*" or "image/*"),
        /// (b) individual file extensions (e.g. ".txt" or ".png"),
        /// (c) combined description and file extension delimited using "|" and ";" (e.g. "Image Types|.png;.gif;.jpg").</param>
        /// <param name="acceptExtensions">provides the semicolon-delimited expansion of MIME
        /// types to file extensions (if known, or empty string otherwise).</param>
        /// <param name="acceptDescriptions">
        /// Provides the descriptions for MIME types (if known, or empty string otherwise).
        /// For example, the 'image/*' mime type might have extensions ".png;.jpg;.bmp;..." and description 'Image Files'
        /// </param>
        /// <param name="callback">Callback interface for asynchronous continuation of file dialog requests.</param>
        /// <returns>To display a custom dialog return true. To display the default dialog return false.</returns>
        protected virtual bool OnFileDialog(
            IWebBrowser chromiumWebBrowser,
            IBrowser browser,
            CefFileDialogMode mode,
            string title,
            string defaultFilePath,
            IReadOnlyCollection<string> acceptFilters,
            IReadOnlyCollection<string> acceptExtensions,
            IReadOnlyCollection<string> acceptDescriptions,
            IFileDialogCallback callback)
        {
            return false;
        }
    }
}
