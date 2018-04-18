'Corn Maze Average time
' Alex MacDonald
' October 26, 2017
'Exam 2
'Purpose: Enter times for all teammates, up to 10, and display average time for team.

Option Strict On

Public Class Form1
    Private Sub mnuClear_Click(sender As Object, e As EventArgs) Handles mnuClear.Click
        'This click event clears t he listbox object and hides the average time label, it also enables the weight loss button
        lstTimes.Items.Clear()
        lblAverageTime.Visible = False
        btnTimes.Enabled = True
    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        'The mnuExit click event closes the window and exits the application
        Close()
    End Sub

    Private Sub btnTimes_Click(sender As Object, e As EventArgs) Handles btnTimes.Click
        'Accepts up to 10 time values
        'and then calculates and ddisplays the average time for the team
        'Decleare and initialize variables
        Dim strTime As String
        Dim decTime As Decimal
        Dim decAverageTime As Decimal
        Dim decTotalTime As Decimal = 0D
        Dim strInputMessage As String = "Enter the weight loss for team member #"
        Dim strInputHeading As String = "Time"
        Dim strNormalMessage As String = "Enter the time for team member #"
        Dim strNonNumericError As String = "Error - enter a number for the weight loss of team member #"
        Dim strNegativeError As String = "Error - Enter a positive number for the time of team member #"

        'dECLARE AND INITIALIZE LOOP VARIABLES

        Dim strCancelClicked As String = ""
        Dim intMaxNumberOfEntries As Integer = 10
        Dim intNumberOfEntries As Integer = 1

        'This loop allows the user to enter the weight loss of up to 10 team members.
        'The loop terminates when the user has entered 10 time values or the user
        'taps or clicks the cancel button or the close button in the inputbox

        strTime = InputBox(strInputMessage & intNumberOfEntries, strInputHeading, " ")

        Do Until intNumberOfEntries > intMaxNumberOfEntries Or strTime = strCancelClicked

            If IsNumeric(strTime) Then
                decTime = Convert.ToDecimal(strTime)
                If decTime > 0 Then
                    lstTimes.Items.Add(decTime)
                    decTotalTime += decTime
                    intNumberOfEntries += 1
                    strInputMessage = strNormalMessage
                Else
                    strInputMessage = strNegativeError
                End If
            Else
                strInputMessage = strNonNumericError
            End If

            If intNumberOfEntries <= intMaxNumberOfEntries Then
                strTime = InputBox(strInputMessage & intNumberOfEntries, strInputHeading, " ")

            End If
        Loop

        'Calculates and displays average team time
        If intNumberOfEntries > 1 Then
            lblAverageTime.Visible = True
            decAverageTime = decTotalTime / (intNumberOfEntries - 1)
            lblAverageTime.Text = "Average time for the team is " &
                decAverageTime.ToString("F1") & " minutes"
        Else
            MsgBox("No time value entered")
        End If

        'disables the time value button
        btnTimes.Enabled = False
    End Sub
End Class
