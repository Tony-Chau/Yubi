Imports System

Module Program
    Sub Main(args As String())
        Dim BrowserRegistryString As String = My.Computer.Registry.ClassesRoot.OpenSubKey("\http\shell\open\command\").GetValue("").ToString
        Dim DefaultBrowserPath As String = System.Text.RegularExpressions.Regex.Match(BrowserRegistryString, "(\"".*?\"")").Captures(0).ToString
        Dim LocalURL As String = "file:///C:/users/matt/desktop/page.htm#test"
        Process.Start(DefaultBrowserPath, LocalURL)
    End Sub
End Module
