Class MainWindow
    Function StringToNum(s As String, b As String) As Double
        Dim Number As Double
        Dim SLength As Integer
        Number = 0
        SLength = s.Length - 1

        For i As Integer = 0 To SLength
            Number += (b.Length ^ (s.Length - i - 1)) * (b.IndexOf(s.Chars(i)))
        Next

        Return Number
    End Function

    Function NumToString(n As Double, b As String, MaxDigits As Integer)
        Dim ReturnString As String
        Dim Remainder As Double
        ReturnString = ""
        Remainder = n

        For i As Integer = MaxDigits To 0 Step -1
            ReturnString += b.Chars(Convert.ToInt32(Remainder / (b.Length ^ i)))
            Remainder = Convert.ToInt32(Remainder Mod (b.Length ^ i))
        Next

        Return ReturnString
    End Function

    Function Transcribe(d As String) As String
        Dim BaseDNA As String
        BaseDNA = "ACGT"

        For Each c As Char In d
            If Not BaseDNA.Contains(c) Then
                Return "DNA Sequence is not in the correct format! (ACGT)"
            End If
        Next

        Return d.Replace("T", "U")
    End Function

    Function Translate(r As String) As String
        Dim BaseRNA As String
        Dim BaseProtein As String
        Dim Peptide As String
        Dim Codon As String
        BaseRNA = "ACGU"
        BaseProtein = "KNKNTTTTRSRSIIMIQHQHPPPPRRRRLLLLEDEDAAAAGGGGVVVV.Y.YSSSS.CWCLFLF"
        Peptide = ""
        Codon = "123"

        For Each c As Char In r
            If Not BaseRNA.Contains(c) Then
                Return "RNA Sequence is not in the correct format! (ACGU)"
            End If
        Next

        Dim CodonLength As Integer
        Dim RNALength As Integer
        CodonLength = 3
        RNALength = r.Length - CodonLength

        For i As Integer = 0 To RNALength Step CodonLength
            Codon = r.Substring(i, CodonLength)
            Peptide += NumToString(StringToNum(Codon, BaseRNA), BaseProtein, 0)
        Next

        Return Peptide
    End Function

    Private Sub Process()
        Dim Transcript As String
        Dim Translation As String
        Transcript = Transcribe(DNA.Text.ToUpper)
        Translation = Translate(Transcript)
        RNA.Text = "RNA Sequence:" & vbCrLf & vbCrLf & Transcript
        Peptide.Text = "Peptide Sequence:" & vbCrLf & vbCrLf & Translation
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Process()
    End Sub

    Private Sub Window_KeyDown(sender As Object, e As KeyEventArgs)
        If e.Key = 6 Then
            Process()
        End If
    End Sub
End Class
