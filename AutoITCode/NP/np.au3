#cs ----------------------------------------------------------------------------

 AutoIt Version: 3.3.14.3
 Author:         myName

 Script Function:
	Template AutoIt script.

#ce ----------------------------------------------------------------------------

; Script Start - Add your code below here

Run ("notepad")
WinWaitActive("Untitled - Notepad")
Send("Now is the time for all good men to come to the aid of their country.")
Send("..")
WinClose("Untitled - Notepad")
WinWaitActive("Notepad", "Save")
;Send("!n")
Send("!s")

;Now the dialog box is opened  for saving
;default path is my document folder.
WinWaitActive("Save As")
Send("AutoNote.txt")

;class is Button2  for save && Button for Cancel
; how to change focus from the input box to the button.
; maybe jsut send the alt S  or !S
Send("!S")