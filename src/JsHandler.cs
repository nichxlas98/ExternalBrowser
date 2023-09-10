using System;
using System.Windows;
using CefSharp;

public class JsHandler : IJsDialogHandler
{
    public bool OnBeforeUnloadDialog(IWebBrowser chromiumWebBrowser, IBrowser browser, string messageText, bool isReload, IJsDialogCallback callback)
    {
        throw new NotImplementedException();
    }

    public void OnDialogClosed(IWebBrowser browserControl, IBrowser browser)
    {
        throw new NotImplementedException();
    }

    public bool OnJSAlert(IWebBrowser browser, string url, string message)
    {
        MessageBox.Show("Alert Detected. Url : " + url + " \n message : " + message);
        return false;
    }

    public bool OnJSBeforeUnload(IWebBrowser browserControl, IBrowser browser, string message, bool isReload, IJsDialogCallback callback)
    {
        throw new NotImplementedException();
    }

    public bool OnJSConfirm(IWebBrowser browser, string url, string message, out bool retval)
    {
        MessageBox.Show("Confirm Detected. Url : " + url + " \n message : " + message);
        retval = false;
        return false;
    }

    public bool OnJSDialog(IWebBrowser browserControl, IBrowser browser, string originUrl, CefJsDialogType dialogType, string messageText, string defaultPromptText, IJsDialogCallback callback, ref bool suppressMessage)
    {
        throw new NotImplementedException();
    }

    public bool OnJSPrompt(IWebBrowser browser, string url, string message, string defaultValue, out bool retval, out string result)
    {
        MessageBox.Show("Prompt Detected. Url : " + url + " \n message : " + message);
        retval = false;
        result = "";
        return false;
    }

    public void OnResetDialogState(IWebBrowser browserControl, IBrowser browser)
    {
        throw new NotImplementedException();
    }
}