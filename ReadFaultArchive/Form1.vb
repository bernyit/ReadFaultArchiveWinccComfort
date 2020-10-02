Imports System.Data.OleDb
Imports System.IO

Public Class Form1

    Dim countAlarmsOpen As Integer
    Dim countAlarmsClosed As Integer




    Private Sub btnRead_Click(sender As Object, e As EventArgs) Handles btnRead.Click


        Dim separator As Char = vbTab

        Dim strfilename As String = "C:\ZZZZ_Chiavetta USB\Faults_Archive0_20190924_073636_HMI_Panel.txt"
        Dim SR As StreamReader = New StreamReader(strfilename)
        Dim filedata As String = SR.ReadToEnd

        filedata = filedata.Replace(vbLf, "")
        filedata = filedata.Replace("""", String.Empty)

        Dim faultsWinccFormat = gio(filedata)

        createStartEndAlarmList(faultsWinccFormat)


        writeResultAlarmList()

    End Sub

    Structure strFaultsArchive
        Dim ms As Double '0
        Dim stateAFter As Int16 '2
        Dim msgNumber As Int16 '4
        Dim dateTimeString As String '13
        Dim msgText As String '14
    End Structure

    Structure strFaultsList
        Dim ms As Double
        Dim msgNumber As Int16
        Dim dateTimeStringBegin As String
        Dim dateTimeStringEnd As String
        Dim duration As Double
        Dim msgText As String
    End Structure


    Public Function gio(ByVal fileData As String) As List(Of strFaultsArchive)

        Dim rows = New List(Of strFaultsArchive)

        Dim arrRow() As String = fileData.Split(Convert.ToChar(Keys.Return))

        For Each row In arrRow
            Dim rowStructured As strFaultsArchive
            Dim separator As Char = vbTab

            Dim arrWork() As String = row.Split(separator)

            Try
                rowStructured.ms = Double.Parse(arrWork(0)) / 1000
                rowStructured.stateAFter = Int16.Parse(arrWork(2))
                rowStructured.msgNumber = Int16.Parse(arrWork(4))
                rowStructured.dateTimeString = arrWork(13)
                rowStructured.msgText = arrWork(14)

                rows.Add(rowStructured)
            Catch ex As Exception

            End Try

        Next

        Return rows

    End Function


    Dim newAlarmlist = New List(Of strFaultsList)

    Private Sub createStartEndAlarmList(ByVal alarmsWincc As List(Of strFaultsArchive))


        For Each alarmEvent In alarmsWincc
            If alarmEvent.stateAFter = 1 Then
                addAlarm(alarmEvent)
                countAlarmsOpen += 1
            Else
                closeAlarm(alarmEvent)
                countAlarmsClosed += 1
            End If
        Next

    End Sub


    Private Sub addAlarm(ByVal alarm As strFaultsArchive)

        Dim newAlarm As strFaultsList

        newAlarm.ms = alarm.ms
        newAlarm.msgNumber = alarm.msgNumber
        newAlarm.dateTimeStringBegin = alarm.dateTimeString
        newAlarm.dateTimeStringEnd = ""
        newAlarm.msgText = alarm.msgText
        newAlarm.duration = -1
        newAlarmlist.Add(newAlarm)

    End Sub

    Private Sub closeAlarm(ByVal alarm As strFaultsArchive)


        For i As Integer = newAlarmlist.Count - 1 To 0 Step -1


            If newAlarmlist(i).msgNumber = alarm.msgNumber Then

                If newAlarmlist(i).dateTimeStringEnd = "" Then

                    Dim newAlarm As strFaultsList

                    newAlarm = newAlarmlist(i)
                    newAlarm.dateTimeStringEnd = alarm.dateTimeString
                    newAlarm.duration = timeCalculation(newAlarm.dateTimeStringBegin, newAlarm.dateTimeStringEnd)

                    newAlarmlist(i) = newAlarm

                End If



                Exit For
            End If

        Next


    End Sub


    Private Function timeCalculation(ByVal startTime As String, ByVal endTime As String) As Double

        Dim returnValue As Double = 0

        Try
            Dim startDate As DateTime = Convert.ToDateTime(startTime)
            Dim endDate As DateTime = Convert.ToDateTime(endTime)
            returnValue = DateDiff(DateInterval.Minute, startDate, endDate)
        Catch ex As Exception

        End Try

        Return returnValue
    End Function




    Private Sub writeResultAlarmList()
        Dim separator As String = ";"
        Dim strfilename As String = "C:\ZZZZ_Chiavetta USB\Faults_Archive0_20190924_073636_HMI_Panel.csv"

        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(strfilename, True)

        For Each LINE As strFaultsList In newAlarmlist

            Dim textLine As String

            textLine = LINE.ms & separator &
                        LINE.msgNumber & separator &
                        LINE.dateTimeStringBegin & separator &
                        LINE.dateTimeStringEnd & separator &
                        LINE.duration & separator &
                        LINE.msgText

            file.WriteLine(textLine)

        Next





        file.Close()

    End Sub

    Private Sub btnSelectOrigin_Click(sender As Object, e As EventArgs) Handles btnSelectOrigin.Click

        OpenFileDialog1.ShowDialog()

        txtSource.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub btnSelectDestination_Click(sender As Object, e As EventArgs) Handles btnSelectDestination.Click
        SaveFileDialog1.ShowDialog()
        txtDestination.Text = SaveFileDialog1.FileName
    End Sub
End Class
