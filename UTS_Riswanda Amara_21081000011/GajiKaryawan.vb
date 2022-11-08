
Imports System.Console
Imports System.IO

Module GajiKaryawan
    'Deklarasi Variabel

    'Variabel Awal
    Dim arrGolongan() As Integer
    Dim arrJabatan() As String
    Dim arrStatusKepegawaian() As String
    Dim arrGajiPokok() As Integer
    Dim arrStatusKawin() As String

    'Variabel Input
    Dim strNama As String
    Dim intGolongan As Integer
    Dim strJabatan As String
    Dim strStatusPegawai As String
    Dim strJK As String
    Dim strStatusKawin As String
    Dim intJmlAnak As Integer

    'Variabel Looping
    Dim loopGolongan As Boolean
    Dim statusGolongan As Boolean

    Dim loopJabatan As Boolean
    Dim statusJabatan As Boolean

    Dim loopStatusPegawai As Boolean
    Dim statusStatusPegawai As Boolean

    Dim loopJK As Boolean
    Dim statusJK As Boolean

    Dim loopStatusKawin As Boolean
    Dim statusStatusKawin As Boolean

    'Variabel Process
    Dim intGajiPokok As Integer
    Dim intTunjanganIstri As Integer
    Dim intTunjanganAnak As Integer
    Dim intGajiBruto As Integer
    Dim intKoperasi As Integer
    Dim intBiayaJabatan As Integer
    Dim intDanaPensiun As Integer
    Dim intGajiNetto As Integer

    Sub Main()
        Menu()
        Input()
        Process()
        Output()

    End Sub

    Sub Menu()
        WriteLine("Golongan         : 1/2/3")
        WriteLine("Jabatan          : KEPALA/MANAGER/UMUM")
        WriteLine("Status Pegawai   : TETAP/HONORER")
        WriteLine("Jenis Kelamin    : P/L")
        WriteLine("Status Kawin     : KAWIN/BELUM KAWIN")
    End Sub

    Sub Input()
        arrGolongan = {1, 2, 3}
        arrGajiPokok = {1500000, 2500000, 3500000}
        arrJabatan = {"KEPALA", "MANAGER", "UMUM"}
        arrStatusKepegawaian = {"TETAP", "HONORER"}
        arrStatusKawin = {"KAWIN", "BELUM KAWIN"}

        loopGolongan = True
        statusGolongan = False
        loopJabatan = True
        statusJabatan = False
        loopStatusPegawai = True
        statusStatusPegawai = False
        loopJK = True
        statusJK = False
        loopStatusKawin = True
        statusStatusKawin = False
        intKoperasi = 0
        intDanaPensiun = 0

        intJmlAnak = 0
        intTunjanganIstri = 0
        intTunjanganAnak = 0

        WriteLine()
        WriteLine("==================================")
        Write(" SLIP GAJI : ")
        strNama = ReadLine()
        WriteLine("==================================")

        Do While loopGolongan = True
            Write(" Input Golongan          : ")
            intGolongan = ReadLine()
            For i = 0 To arrGolongan.Length - 1
                If intGolongan = arrGolongan(i) Then
                    loopGolongan = False
                    statusGolongan = True
                    Exit For
                End If
            Next
            If statusGolongan = False Then
                WriteLine("Masukkan ulang data!")
            End If
        Loop

        Do While loopJabatan = True
            Write(" Input Jabatan           : ")
            strJabatan = UCase(ReadLine())
            For i = 0 To arrJabatan.Length - 1
                If strJabatan = arrJabatan(i) Then
                    loopJabatan = False
                    statusJabatan = True
                    Exit For
                End If
            Next
            If statusJabatan = False Then
                WriteLine("Masukkan ulang data!   ")
            End If
        Loop

        Do While loopStatusPegawai = True
            Write(" Input Status Pegawai    : ")
            strStatusPegawai = UCase(ReadLine())
            For i = 0 To arrStatusKepegawaian.Length - 1
                If strStatusPegawai = arrStatusKepegawaian(i) Then
                    loopStatusPegawai = False
                    statusStatusPegawai = True
                End If
            Next
            If statusStatusPegawai = False Then
                WriteLine("Masukkan ulang data!   ")
            End If
        Loop

        Do While loopJK = True
            Write(" Input Jenis Kelamin     : ")
            strJK = UCase(ReadLine())
            If strJK <> "P" And strJK <> "L" Then
                WriteLine("Masukkan data kembali!   ")
            Else
                loopJK = False
                statusJK = True
            End If
        Loop

        Do While loopStatusKawin = True
            Write(" Input Status Kawin      : ")
            strStatusKawin = UCase(ReadLine())
            For i = 0 To arrStatusKawin.Length - 1
                If strStatusKawin = arrStatusKawin(i) Then
                    loopStatusKawin = False
                    statusStatusKawin = True
                    Exit For
                End If
            Next
            If statusStatusKawin = False Then
                WriteLine("Masukkan ulang data!   ")
            End If
        Loop

        If strStatusKawin = arrStatusKawin(0) Then
            Write(" Input Jumlah Anak       : ")
            intJmlAnak = intJmlAnak + ReadLine()
        End If
    End Sub

    Sub Process()

        'Process Gaji Pokok
        intGajiPokok = arrGajiPokok(intGolongan - 1)

        'Process Tunjangan Istri
        If strJK = "L" And strStatusKawin = "KAWIN" Then
            If intGolongan = 1 Then
                intTunjanganIstri = 0.01 * (arrGajiPokok(intGolongan - 1))
            ElseIf intGolongan = 2 Then
                intTunjanganIstri = 0.03 * (arrGajiPokok(intGolongan - 1))
            ElseIf intGolongan = 3 Then
                intTunjanganIstri = 0.05 * (arrGajiPokok(intGolongan - 1))
            End If
        End If

        'Process Tunjangan Anak
        If strStatusKawin = "KAWIN" And intJmlAnak > 0 Then
            If intJmlAnak <= 2 Then
                intTunjanganAnak = (0.01 * arrGajiPokok(intGolongan - 1)) * intJmlAnak
            Else
                intTunjanganAnak = (0.01 * arrGajiPokok(intGolongan - 1)) * 2
            End If
        End If

        'Process Gaji Bruto
        intGajiBruto = intGajiPokok + intTunjanganAnak + intTunjanganIstri

        'Process Potongan Koperasi
        If strStatusPegawai = "TETAP" Then
            intKoperasi = 5000
        End If

        'Process Biaya Jabatan
        If strJabatan = "KEPALA" Then
            intBiayaJabatan = 0.005 * intGajiPokok
        ElseIf strJabatan = "MANAGER" Then
            intBiayaJabatan = 0.003 * intGajiPokok
        End If

        'Dana Pensiun
        If strStatusPegawai = "TETAP" Then
            If strJabatan = "KEPALA" Then
                intDanaPensiun = 0.005 * intGajiPokok
            ElseIf strJabatan = "MANAGER" Then
                intDanaPensiun = 0.003 * intGajiPokok
            End If
        End If

        'Process Gaji Netto
        intGajiNetto = intGajiBruto - (intKoperasi + intBiayaJabatan + intDanaPensiun)

    End Sub

    Sub Output()
        'Command Prompt
        Clear()
        WriteLine()
        WriteLine("=========================================")
        WriteLine(" SLIP GAJI : " & strNama)
        WriteLine("=========================================")
        WriteLine(" 1. Golongan           = " & intGolongan)
        WriteLine(" 2. Jabatan            = " & strJabatan)
        WriteLine(" 3. Status Pegawai     = " & strStatusPegawai)
        WriteLine(" 4. Jenis Kelamin      = " & strJK)
        WriteLine(" 5. Status Kawin       = " & strStatusKawin)
        WriteLine(" 6. Jumlah Anak        = " & intJmlAnak)
        WriteLine(" 7. Gaji Pokok         = " & FormatNumber(Convert.ToInt32(intGajiPokok)), 0, TriState.True, 0)
        WriteLine(" 8. Tunjangan Istri    = " & FormatNumber(Convert.ToInt32(intTunjanganIstri)), 0, TriState.True, 0)
        WriteLine(" 9. Tunjangan Anak     = " & FormatNumber(Convert.ToInt32(intTunjanganAnak)), 0, TriState.True, 0)
        WriteLine("         Gaji Bruto    = " & FormatNumber(Convert.ToInt32(intGajiBruto)), 0, TriState.True, 0)
        WriteLine(" 10. Potongan Koperasi = " & FormatNumber(Convert.ToInt32(intKoperasi)), 0, TriState.True, 0)
        WriteLine(" 11. Biaya Jabatan     = " & FormatNumber(Convert.ToInt32(intBiayaJabatan)), 0, TriState.True, 0)
        WriteLine(" 12. Biaya Pensiun     = " & FormatNumber(Convert.ToInt32(intDanaPensiun)), 0, TriState.True, 0)
        WriteLine("         Gaji Netto      = " & FormatNumber(Convert.ToInt32(intGajiNetto)), 0, TriState.True, 0)
        WriteLine("=========================================")

        'Notepad Output
        Dim tanggal As String = DateTime.Now.ToString("dd'-'MM'-'yyyy-HH-mm-ss")
        Dim file As String

        file = strNama & " " & tanggal & ".txt"
        Dim notepad As StreamWriter

        notepad = My.Computer.FileSystem.OpenTextFileWriter("D:\" & file, True)

        notepad.WriteLine()
        notepad.WriteLine("=========================================")
        notepad.WriteLine(" SLIP GAJI : " & strNama)
        notepad.WriteLine("=========================================")
        notepad.WriteLine(" 1. Golongan           = " & intGolongan)
        notepad.WriteLine(" 2. Jabatan            = " & strJabatan)
        notepad.WriteLine(" 3. Status Pegawai     = " & strStatusPegawai)
        notepad.WriteLine(" 4. Jenis Kelamin      = " & strJK)
        notepad.WriteLine(" 5. Status Kawin       = " & strStatusKawin)
        notepad.WriteLine(" 6. Jumlah Anak        = " & intJmlAnak)
        notepad.WriteLine(" 7. Gaji Pokok         = " & FormatNumber(Convert.ToInt32(intGajiPokok)), 0, TriState.True, 0)
        notepad.WriteLine(" 8. Tunjangan Istri    = " & FormatNumber(Convert.ToInt32(intTunjanganIstri)), 0, TriState.True, 0)
        notepad.WriteLine(" 9. Tunjangan Anak     = " & FormatNumber(Convert.ToInt32(intTunjanganAnak)), 0, TriState.True, 0)
        notepad.WriteLine("         Gaji Bruto    = " & FormatNumber(Convert.ToInt32(intGajiBruto)), 0, TriState.True, 0)
        notepad.WriteLine(" 10. Potongan Koperasi = " & FormatNumber(Convert.ToInt32(intKoperasi)), 0, TriState.True, 0)
        notepad.WriteLine(" 11. Biaya Jabatan     = " & FormatNumber(Convert.ToInt32(intBiayaJabatan)), 0, TriState.True, 0)
        notepad.WriteLine(" 12. Biaya Pensiun     = " & FormatNumber(Convert.ToInt32(intDanaPensiun)), 0, TriState.True, 0)
        notepad.WriteLine("         Gaji Netto      = " & FormatNumber(Convert.ToInt32(intGajiNetto)), 0, TriState.True, 0)
        notepad.WriteLine("=========================================")
        notepad.Close()

    End Sub



End Module
