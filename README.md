 # Sticky Clip

 Sticky clip is a sticky note program that can easily create new memo by copying/cutting markdown textblock.

## Instruction

After launch, application monitors clipboard. If new text starts with **command initiator token** has been written to clipboard, trailing text without **command initiator token** is parsed and new sticky note is created accordingly.


## `.config` Configuration file

| Name                      | Allowed Type |      Default    | Description |
|---------------------------|:------------:|:---------------:|-------------|
|   CommandInitiatorToken   |   `string`   |  !    | Text starts with this token is considered as a note creation command and processed by Sticky Clip |
|   DefaultSize             |  `int, int`  |  200, 200    | Default size of new sticker note |
|   SaveFile                |   `string`   |  SavedNotes.json    | Filename of save file |
|   EditorFontSize          |     `int`    |  13    | Font size of markdown editor in **pt**. |
