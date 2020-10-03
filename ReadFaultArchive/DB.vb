Public Class DB

    Shared DBobjLock As New Object



    Public Shared Sub InsertAlarmDefinition(ByVal alarmId As Int32, ByVal alarmDescription As String, ByVal alarmClass As Int16)

        Using TTA_ALARM_DEFINITION As WinCCComfortTableAdapters.alarmDefinitionTableAdapter = New WinCCComfortTableAdapters.alarmDefinitionTableAdapter
            Try
                SyncLock DBobjLock

                    Dim alarmPresence As Int16 = TTA_ALARM_DEFINITION.SelectAlarmById(alarmId)

                    If alarmPresence = 0 Then
                        TTA_ALARM_DEFINITION.InsertAlarmDefinition(alarmId, alarmDescription, alarmClass)
                    Else
                        TTA_ALARM_DEFINITION.UpdateAlarmDefinition(alarmClass, alarmDescription, alarmId)
                    End If



                End SyncLock

            Catch ex As Exception

                MsgBox(ex.Message)
            End Try

        End Using

    End Sub





    Public Shared Sub InsertAlarm(ByVal alarmId As Int32, ByVal strTime As String, ByVal auxVal As Int16, ByVal stateAfter As Int16, ByVal description As String)

        Using TTA_ALARM As WinCCComfortTableAdapters.alarmListTableAdapter = New WinCCComfortTableAdapters.alarmListTableAdapter
            Try
                SyncLock DBobjLock

                    Dim oDate As DateTime = DateTime.ParseExact(strTime, "yyyy-MM-dd HH:mm:ss", Nothing)

                    Select Case stateAfter
                        Case 1 'New Alarm
                            Try
                                TTA_ALARM.InsertNewAlarm(oDate, alarmId, auxVal, description)
                            Catch ex As Exception
                                'log 
                            End Try

                        Case 0 'alarm solved
                            TTA_ALARM.CloseAlarm(oDate, alarmId)

                        Case 2, 3, 6
                            TTA_ALARM.ackAlarm(oDate, alarmId)

                    End Select

                End SyncLock

            Catch ex As Exception

                MsgBox(ex.Message)
            End Try

        End Using

    End Sub








End Class
