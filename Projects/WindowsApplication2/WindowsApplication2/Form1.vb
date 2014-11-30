VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Модель СМО"
   ClientHeight    =   3030
   ClientLeft      =   120
   ClientTop       =   450
   ClientWidth     =   4560
   LinkTopic       =   "Form1"
   ScaleHeight     =   3030
   ScaleWidth      =   4560
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox Text8 
      Height          =   375
      Left            =   2760
      TabIndex        =   10
      Text            =   "Text8"
      Top             =   840
      Width           =   735
   End
   Begin VB.TextBox Text7 
      Height          =   375
      Left            =   2760
      TabIndex        =   9
      Text            =   "Text7"
      Top             =   1320
      Width           =   855
   End
   Begin VB.TextBox Text6 
      Height          =   285
      Left            =   1800
      TabIndex        =   8
      Text            =   "Text6"
      Top             =   1920
      Width           =   735
   End
   Begin VB.TextBox Text5 
      Height          =   375
      Left            =   2880
      TabIndex        =   7
      Text            =   "Text5"
      Top             =   1920
      Width           =   1095
   End
   Begin VB.TextBox Text4 
      Height          =   495
      Left            =   2760
      TabIndex        =   6
      Text            =   "Text4"
      Top             =   240
      Width           =   855
   End
   Begin VB.TextBox Text3 
      Height          =   495
      Left            =   1800
      TabIndex        =   5
      Text            =   "Text3"
      Top             =   1320
      Width           =   855
   End
   Begin VB.TextBox Text2 
      Height          =   495
      Left            =   1800
      TabIndex        =   4
      Text            =   "Text2"
      Top             =   240
      Width           =   855
   End
   Begin VB.TextBox Text1 
      Height          =   495
      Left            =   1800
      TabIndex        =   3
      Text            =   "Text1"
      Top             =   840
      Width           =   855
   End
   Begin VB.CommandButton Command3 
      Caption         =   "Выход"
      Height          =   495
      Left            =   240
      TabIndex        =   2
      Top             =   1680
      Width           =   975
   End
   Begin VB.CommandButton Command2 
      Caption         =   "очистка"
      Height          =   615
      Left            =   240
      TabIndex        =   1
      Top             =   840
      Width           =   1335
   End
   Begin VB.CommandButton Command1 
      Caption         =   "расчёт"
      Height          =   495
      Left            =   240
      TabIndex        =   0
      Top             =   240
      Width           =   975
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Const Nzmax = 100
Const NKmax = 5
Dim Tz(Nzmax)
Dim Nobs(NKmax)
Dim TOK(NKmax)
Dim TZcp, Tobscp, Tfin, TWmax, TKmin, TH, TK, z, Ts
Dim SNobs As Long, Iz, Nz, Ir, Nr, J, Nkan, Jmin

Private Sub Command1_Click()

    Nkan = Val(Text1.Text) : TZcp = Val(Text2.Text) : Tobscp = Val(Text3.Text)
    DTobs = Val(Text4.Text) : TWmax = Val(Text5.Text) : Tfin = Val(Text6.Text)
    Nr = Val(Text7.Text)
    Call Raschet()

End Sub
Sub Raschet()
    SNob = 0
    For Ir = 1 To Nr
        Nz = 0
        Print Nr
        For i = 1 To NKmax
            Nobs(i) = 0 : TOK(i) = 0
        Next
        Call ZAJAVKA()
        For Iz = 1 To Nz
            TKmin = 100
            For J = 1 To Nkan
                If TOK(J) < TKmin Then TKmin = TOK(J) : Jmin = J
            Next J
            If Nr = 1 Then Call Debug2()
            Call SERVICE()
        Next Iz
        For i = 1 To Nkan
            SNobs = SNobs + Nobs(i)
        Next i
    Next Ir
    Cotn = SNobs / Nr - 1 + 0.5 * Nkan - 0.5 * Nkan * Nkan
    Form1.Text8.ForeColor = &HFF
    Form1.Text8 = Format$(Cotn, "0.0")
End Sub
Sub ZAJAVKA()
    T = 0
    For J = 1 To Nzmax
        z = Rnd(1)
        Ts = T - TZcp * Log(z)
        If Ts > Tfin * 60 Then Exit For
        Nz = Nz + 1
        Tz(Nz) = Ts
        T = Ts
    Next J
End Sub
Sub SERVICE()
    J = Jmin
    DTWait = 0
    TH = Tz(Iz)
    If Tz(Iz) < TOK(J) Then
        DTWait = TOK(J) - Tz(Iz)
        If DTWait > TWmax Then Exit Sub
        TH = TOK(J)
    End If
    z = Rnd(1)
    TK = TH + Tobscp + DTads * (z - 0.5)
    If TK > Tfin * 60 Then
        TOK(J) = Tfin : Exit Sub
    End If
    Nobs(J) = Nobs(J) + 1
    TOK(J) = TK
    If Nr = 1 Then Call Debug4()
End Sub

Private Sub Command2_Click()
    Text8.Text = ""
End Sub

Private Sub Command3_Click()
    End
End Sub
