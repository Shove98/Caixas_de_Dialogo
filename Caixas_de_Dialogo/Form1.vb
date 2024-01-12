Imports System.IO
Public Class Form1
    Private Sub AbrirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirToolStripMenuItem.Click
        Me.OpenFileDialog1.Title = "Abrir..."
        Me.OpenFileDialog1.FileName = ""
        Me.OpenFileDialog1.Filter = "Ficheiros de texto(*.txt) | *.txt | Todos (*.*) | *.*"
        Me.OpenFileDialog1.FilterIndex = 1
        If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.TextBox1.Text = File.ReadAllText(Me.OpenFileDialog1.FileName)
            Me.TextBox1.Tag = Nothing
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.Tag = "Alterado"
    End Sub

    Private Sub NovoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NovoToolStripMenuItem.Click
        If TextBox1.Tag IsNot Nothing Then
            Dim res As DialogResult
            res = MessageBox.Show("O documento foi alterado. Deseja continuar?", "Editor de Notas", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
            If res <> Windows.Forms.DialogResult.Yes Then
                Return
            End If
        End If
        Me.TextBox1.Text = String.Empty
        Me.TextBox1.Tag = Nothing
    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        Me.SaveFileDialog1.Title = "Guardar..."
        Me.SaveFileDialog1.DefaultExt = "txt"
        Me.SaveFileDialog1.Filter = "Ficheiros de texto (*.txt) | *.txt"
        Me.SaveFileDialog1.DefaultExt = "txt"

        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            File.WriteAllText(Me.SaveFileDialog1.FileName, Me.TextBox1.Text)
        End If
    End Sub

    Private Sub SairToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SairToolStripMenuItem.Click
        If TextBox1.Tag IsNot Nothing Then
            Dim res As DialogResult
            res = MessageBox.Show("O documento foi alterado. Deseja continuar?", "Editor de Notas", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
            If res <> Windows.Forms.DialogResult.Yes Then
                Return
            End If
        End If
        Application.Exit()
    End Sub

    Private Sub FormatarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FormatarToolStripMenuItem.Click

    End Sub

    Private Sub CorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CorToolStripMenuItem.Click
        Me.ColorDialog1.Color = TextBox1.ForeColor

        If Me.ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.TextBox1.ForeColor = Me.ColorDialog1.Color
        End If
    End Sub

    Private Sub TipoDeLetraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TipoDeLetraToolStripMenuItem.Click
        Me.FontDialog1.ShowColor = True
        Me.FontDialog1.Color = TextBox1.ForeColor

        If Me.FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.TextBox1.Font = Me.FontDialog1.Font
            Me.TextBox1.ForeColor = Me.FontDialog1.Color
        End If
    End Sub
End Class
