' a SCUOLA con VISUAL BASIC 2010 EXPRESS
' http://vbscuola.it
' Pier Luigi Farri; Giovanni Piotti; Sandro Sbroggiò
' https://www.edatlas.it/scarica/SIA_3/Capitolo7/MaterialiOnLine/2ApplicazioniGrafiche.pdf
' © Istituto Italiano Edizioni Atlas - Pag. 6 
Public Class Form1
    ' Estremi del piano cartesiano
    Const minX As Single = -8
    Const maxX As Single = 8
    Const minY As Single = -8
    Const maxY As Single = 8
    ' Larghezza (= altezza) dell'area del grafico
    Dim l As Short
    ' Unità di misura in pixel
    Dim u As Single
    ' Coordinate di un punto
    Dim X0, Y0 As Integer
    Dim X1, Y1, X2, Y2 As Double
    ' Oggetto grafico
    Dim Piano As Graphics

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Piano = PictureBox1.CreateGraphics()
        ' Dimensioni del PictureBox
        l = PictureBox1.Size.Width
        ' Unità di misura
        u = l / (maxX - minX)
        ' Origine
        X0 = PictureBox1.Size.Width / 2        'X0 = u
        Y0 = PictureBox1.Size.Height / 2       'Y0 = maxY * u
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Piano.Clear(PictureBox1.BackColor)
        DisegnaAssi()
        Dim x As Single
        Dim j As Integer
        j = 1
        For x = minX To maxX Step 0.1
            X1 = X0 + x * u
            Y1 = Y0 - F(x, j) * u
            X2 = X0 + (x + 0.1) * u
            Y2 = Y0 - F(x + 0.1, j) * u
            Segmento(j, X1, Y1, X2, Y2)
            'stampa tabulare
            TextBox1.Text &= ("X= ") & x & ("   Y= ") & F(x, j) & vbCrLf
        Next x
    End Sub

    Public Sub DisegnaAssi()
        Dim pen As New Pen(Color.Black, 1)
        'Asse x
        X1 = X0 + minX * u
        Y1 = Y0
        X2 = X0 + maxX * u
        Y2 = Y0
        Piano.DrawLine(pen, CInt(X1), CInt(Y1), CInt(X2), CInt(Y2))
        'Asse y
        X1 = X0
        Y1 = Y0 - minY * u
        X2 = X0
        Y2 = Y0 - maxY * u
        Piano.DrawLine(pen, CInt(X1), CInt(Y1), CInt(X2), CInt(Y2))
        pen.Dispose()
    End Sub

    Public Sub Segmento(ByVal nf As Integer, ByVal a As Double, ByVal b As Double, ByVal c As Double, ByVal d As Double)
        Dim col As Color
        col = Color.Red
        Dim pen As New Pen(col, 1)
        Piano.DrawLine(pen, CInt(a), CInt(b), CInt(c), CInt(d))
        pen.Dispose()
    End Sub

    Public Function F(ByVal i As Single, ByVal nf As Integer) As Double
        'F = Math.Exp(i)
        'F = 12.5 * i - 12.5 * i ^ 2
        F = Math.Sin(i) / i
        Return (F)
    End Function
End Class

