Imports System.Drawing.Imaging
Imports System.IO
'
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports Guna.UI2.WinForms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
'
Imports Microsoft.Win32

Public Class developer_ibrahim_celik53


    'yo19
    'Reedited & updated for 64 bit by software developer IBRAHIM CELIK
    'YouTube: @devibrahimcelik | : https://www.youtube.com/@devibrahimcelik
    'Github: https://github.com/SoftwareDEVibrahimcelik
    'Instagram: softwaredevic
    'Donate Bitcoin Address: 3H2iUqWmQ2RGTYDjJwceVeEFT8XMTafjrk


    Public Declare Function GetAsyncKeyState Lib "user32.dll" (vKey As Keys) As Short


    <DllImport("gdi32.dll")>
    Public Shared Function BitBlt(ByVal hdcDest As IntPtr, ByVal nXDest As Integer, ByVal nYDest As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hdcSrc As IntPtr, ByVal nXSrc As Integer, ByVal nYSrc As Integer, ByVal dwRop As Integer) As Boolean
    End Function

    <DllImport("user32.dll")>
    Public Shared Function GetDesktopWindow() As IntPtr
    End Function

    <DllImport("gdi32.dll")>
    Public Shared Function CreateCompatibleDC(ByVal hDC As IntPtr) As IntPtr
    End Function

    <DllImport("gdi32.dll")>
    Public Shared Function CreateCompatibleBitmap(ByVal hdc As IntPtr, ByVal nWidth As Integer, ByVal nHeight As Integer) As IntPtr
    End Function

    <DllImport("gdi32.dll")>
    Public Shared Function SelectObject(ByVal hdc As IntPtr, ByVal hObject As IntPtr) As IntPtr
    End Function

    <DllImport("gdi32.dll")>
    Public Shared Function DeleteDC(ByVal hdc As IntPtr) As Boolean
    End Function

    <DllImport("gdi32.dll")>
    Public Shared Function DeleteObject(ByVal hObject As IntPtr) As Boolean
    End Function

    Private Sub developer_ibrahim_celik53_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        ListView1.Items.Clear()
        ListView1.View = View.LargeIcon
        Dim imageList As New ImageList()
        imageList.ImageSize = New Size(64, 64)
        Dim screenshotsFolder As String = Path.Combine(Application.StartupPath, "Screenshots")
        If Directory.Exists(screenshotsFolder) Then
            Dim imageFiles = Directory.GetFiles(screenshotsFolder, "*.png")
            For Each imagePath In imageFiles
                imageList.Images.Add(Image.FromFile(imagePath))
                Dim fileName = Path.GetFileName(imagePath)
                Dim item As New ListViewItem(fileName)
                item.ImageIndex = imageList.Images.Count - 1
                ListView1.Items.Add(item)
            Next
            ListView1.LargeImageList = imageList
        End If
        '

        If bildirimbox2.Checked = True Then
            Bildirim.BalloonTipTitle = "Welcome to Screenshot Pro "
            Bildirim.BalloonTipText = "Notify you for the use of this Screenshot Pro"
            Bildirim.ShowBalloonTip(1000)
        End If


    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim screenshotsFolder As String = Path.Combine(Application.StartupPath, "Screenshots")
        Process.Start("explorer.exe", screenshotsFolder)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If ListView1.SelectedItems.Count > 0 Then
            Dim selectedFileName As String = ListView1.SelectedItems(0).Text
            Dim screenshotsFolder As String = Path.Combine(Application.StartupPath, "Screenshots")
            Dim selectedFilePath As String = Path.Combine(screenshotsFolder, selectedFileName)
            Try
                Dim desktopPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                Dim destinationPath As String = Path.Combine(desktopPath, selectedFileName)
                File.Copy(selectedFilePath, destinationPath, True)
                MessageBox.Show("Dosya başarıyla masaüstüne kopyalandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Dosya kopyalama hatası: " & ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub ekranresmibox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ekranresmibox.SelectedIndexChanged
        resimtusu.Text = ekranresmibox.SelectedItem.ToString()
    End Sub


    Private Sub alanbox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles alanbox.SelectedIndexChanged
        alantusu.Text = alanbox.SelectedItem.ToString()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        On Error Resume Next

        Dim vKey As Keys = CType(New KeysConverter().ConvertFromString(resimtusu.Text), Keys)
        Dim vKey2 As Keys = CType(New KeysConverter().ConvertFromString(alantusu.Text), Keys)


        If GetAsyncKeyState(vKey) Then
            Me.Visible = False

            Dim bounds As Rectangle = Screen.PrimaryScreen.Bounds
            Dim screenshot As New Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            Dim gfxScreenshot As Graphics = Graphics.FromImage(screenshot)
            gfxScreenshot.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)


            Dim folderPath As String = Path.Combine(Application.StartupPath, "Screenshots")
            If Not Directory.Exists(folderPath) Then
                Directory.CreateDirectory(folderPath)
            End If

            Dim fileName As String = $"Screenshot Pro__{DateTime.Now.ToString("HHmmss")}.png"

            Dim filePath As String = Path.Combine(folderPath, fileName)
            screenshot.Save(filePath, System.Drawing.Imaging.ImageFormat.Png)

            ListView1.Items.Clear()
            ListView1.View = View.LargeIcon
            Dim imageList As New ImageList()
            imageList.ImageSize = New Size(64, 64)
            Dim screenshotsFolder As String = Path.Combine(Application.StartupPath, "Screenshots")
            If Directory.Exists(screenshotsFolder) Then
                Dim imageFiles = Directory.GetFiles(screenshotsFolder, "*.png")
                For Each imagePath In imageFiles
                    imageList.Images.Add(Image.FromFile(imagePath))
                    Dim fileName3 = Path.GetFileName(imagePath)
                    Dim item As New ListViewItem(fileName3)
                    item.ImageIndex = imageList.Images.Count - 1
                    ListView1.Items.Add(item)
                Next
                ListView1.LargeImageList = imageList
            End If


            '
            '
            Me.Visible = True
            If bildirimbox.Checked = True Then
                MessageBox.Show($"Screenshot is saved: {filePath}", "Screenshot Pro", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            If bildirimbox2.Checked = True Then
                Bildirim.BalloonTipTitle = "Screenshot Pro "
                Bildirim.BalloonTipText = "Screenshot is saved  " & fileName
                Bildirim.ShowBalloonTip(1000)
            End If

        End If





        If GetAsyncKeyState(vKey2) Then


            Me.Visible = False

            Using captureForm2 As New CaptureForm()
                captureForm2.TopMost = True
                If captureForm2.ShowDialog() = DialogResult.OK Then
                    Dim screenshot2 As Bitmap = New Bitmap(captureForm2.SelectedRegion.Width, captureForm2.SelectedRegion.Height)
                    Using g As Graphics = Graphics.FromImage(screenshot2)
                        g.CopyFromScreen(captureForm2.SelectedRegion.Location, New Point(0, 0), screenshot2.Size)
                    End Using

                    Dim folderPath2 As String = Path.Combine(Application.StartupPath, "Screenshots")
                    If Not Directory.Exists(folderPath2) Then
                        Directory.CreateDirectory(folderPath2)
                    End If

                    Dim fileName2 As String = $"Screenshot Pro__{DateTime.Now.ToString("HHmmss")}.png"
                    Dim filePath2 As String = Path.Combine(folderPath2, fileName2)

                    screenshot2.Save(filePath2, ImageFormat.Png)




                    ListView1.Items.Clear()
                    ListView1.View = View.LargeIcon
                    Dim imageList As New ImageList()
                    imageList.ImageSize = New Size(64, 64)
                    Dim screenshotsFolder As String = Path.Combine(Application.StartupPath, "Screenshots")
                    If Directory.Exists(screenshotsFolder) Then
                        Dim imageFiles = Directory.GetFiles(screenshotsFolder, "*.png")
                        For Each imagePath In imageFiles
                            imageList.Images.Add(Image.FromFile(imagePath))
                            Dim fileName4 = Path.GetFileName(imagePath)
                            Dim item As New ListViewItem(fileName4)
                            item.ImageIndex = imageList.Images.Count - 1
                            ListView1.Items.Add(item)
                        Next
                        ListView1.LargeImageList = imageList
                    End If

                    Me.Visible = True
                    '

                    If bildirimbox.Checked = True Then
                        MessageBox.Show($"Screenshot is saved: {filePath2}", "Screenshot Pro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    If bildirimbox2.Checked = True Then
                        Bildirim.BalloonTipTitle = "Screenshot Pro "
                        Bildirim.BalloonTipText = "Screenshot is saved  " & fileName2
                        Bildirim.ShowBalloonTip(1000)
                    End If


                End If
            End Using

            Me.Show()

        End If

        'sonra

        If GetAsyncKeyState(Keys.Insert) Then
            Me.Visible = True
        End If
        If GetAsyncKeyState(Keys.Home) Then
            Me.Visible = False
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ListView1.SelectedItems.Count > 0 Then
            Dim selectedFileName As String = ListView1.SelectedItems(0).Text
            Dim screenshotsFolder As String = Path.Combine(Application.StartupPath, "Screenshots")
            Dim selectedFilePath As String = Path.Combine(screenshotsFolder, selectedFileName)
            Process.Start(selectedFilePath)
        End If
    End Sub

    Private Sub Bildirim_BalloonTipClicked(sender As Object, e As EventArgs) Handles Bildirim.BalloonTipClicked
        If ListView1.Items.Count > 0 Then
            Dim selectedFileName As String = ListView1.Items(ListView1.Items.Count - 1).Text
            Dim screenshotsFolder As String = Path.Combine(Application.StartupPath, "Screenshots")
            Dim selectedFilePath As String = Path.Combine(screenshotsFolder, selectedFileName)
            Process.Start(selectedFilePath)
        End If
    End Sub

    Private Sub yenile_Click(sender As Object, e As EventArgs) Handles yenile.Click
        ListView1.Items.Clear()
        ListView1.View = View.LargeIcon
        Dim imageList As New ImageList()
        imageList.ImageSize = New Size(64, 64)
        Dim screenshotsFolder As String = Path.Combine(Application.StartupPath, "Screenshots")
        If Directory.Exists(screenshotsFolder) Then
            Dim imageFiles = Directory.GetFiles(screenshotsFolder, "*.png")
            For Each imagePath In imageFiles
                imageList.Images.Add(Image.FromFile(imagePath))
                Dim fileName = Path.GetFileName(imagePath)
                Dim item As New ListViewItem(fileName)
                item.ImageIndex = imageList.Images.Count - 1
                ListView1.Items.Add(item)
            Next
            ListView1.LargeImageList = imageList
        End If
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        If ListView1.SelectedItems.Count > 0 Then
            Dim selectedFileName As String = ListView1.SelectedItems(0).Text
            Dim screenshotsFolder As String = Path.Combine(Application.StartupPath, "Screenshots")
            Dim selectedFilePath As String = Path.Combine(screenshotsFolder, selectedFileName)
            Process.Start(selectedFilePath)
        End If
    End Sub

    Private Sub CheckBox1_Click(sender As Object, e As EventArgs) Handles CheckBox1.Click

        If CheckBox1.Checked = True Then
            Dim uygulamaYolu As String = Application.StartupPath & "\Screenshot Pro.exe"

            Try
                Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
                key.SetValue("Screenshot Pro", uygulamaYolu)
                key.Close()
            Catch ex As Exception
            End Try
        End If

        If CheckBox1.Checked = False Then
            Try
                Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
                Dim uygulamaAdi As String = "Screenshot Pro"
                If key.GetValue(uygulamaAdi) IsNot Nothing Then
                    key.DeleteValue(uygulamaAdi)
                End If

                key.Close()
            Catch ex As Exception
            End Try
        End If



    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick


        Label9.Location = New Point(Label9.Location.X, Label9.Location.Y + 1)


        Label9.Location = New Point(Label9.Location.X, Label9.Location.Y - 2)


        If Label9.Location.Y = 100 Then
            Label9.Location = New Point(Label9.Location.X, Label9.Location.Y + 300)
        End If


    End Sub

    Public Class CaptureForm
        Inherits Form

        Public Property SelectedRegion As Rectangle

        Public Sub New()
            Me.FormBorderStyle = FormBorderStyle.None
            Me.WindowState = FormWindowState.Maximized
            Me.BackColor = Color.Black
            Me.Opacity = 0.5
            Me.Cursor = Cursors.Cross
        End Sub

        Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
            MyBase.OnMouseDown(e)
            SelectedRegion = New Rectangle(e.Location, New Size(0, 0))
        End Sub

        Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
            MyBase.OnMouseMove(e)
            If e.Button = MouseButtons.Left Then
                SelectedRegion = New Rectangle(SelectedRegion.Location, New Size(e.X - SelectedRegion.Left, e.Y - SelectedRegion.Top))
                Me.Invalidate()
            End If
        End Sub

        Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
            MyBase.OnMouseUp(e)
            If e.Button = MouseButtons.Left Then
                DialogResult = DialogResult.OK
                Me.Close()
            End If
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)
            Using pen As New Pen(Color.Red, 2)
                e.Graphics.DrawRectangle(pen, SelectedRegion)
            End Using

        End Sub
    End Class

    Private Sub Dilbutonu_Click(sender As Object, e As EventArgs) Handles Dilbutonu.Click
        Screenshot_Pro.Show()
        MsgBox("Not finished yet")
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        System.Diagnostics.Process.Start("https://discord.com/invite/HBBkbneJ49")
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Clipboard.SetDataObject("3H2iUqWmQ2RGTYDjJwceVeEFT8XMTafjrk")
    End Sub

    Private Sub Instagrambtn_Click(sender As Object, e As EventArgs) Handles Instagrambtn.Click
        System.Diagnostics.Process.Start("https://www.instagram.com/softwaredevic/p/C2pOtE4MN10/")
        MsgBox("Instagram : @softwaredevic")
    End Sub

    Private Sub Button32_Click(sender As Object, e As EventArgs) Handles Button32.Click
        System.Diagnostics.Process.Start("https://www.youtube.com/@devibrahimcelik")
    End Sub

    Private Sub Button33_Click(sender As Object, e As EventArgs) Handles Button33.Click
        System.Diagnostics.Process.Start("https://github.com/SoftwareDEVibrahimcelik")
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        System.Diagnostics.Process.Start("https://steamcommunity.com/profiles/76561199096175384/")
    End Sub
End Class
