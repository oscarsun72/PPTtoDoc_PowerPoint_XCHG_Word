Attribute VB_Name = "FontsOps"
Option Explicit
Sub removeNoFont()
Const fontname As String = "�Ш|������"
Dim a
For Each a In ThisDocument.Characters
     If a.Font.NameFarEast <> "�Ш|������" Then
        a.Delete
     End If
Next a
End Sub
