# UNO Project

## Authors and respective tasks:
 * ### Gulherme Felicissimo - 21903863
    * Code Refactoring
    * Made "Skip", "Reverse" and "Wildcard" card types
    * Code Re-Organization
    * Added Card Class and Deck of Card class
 * ### Ritik Joshi - 22002818
    * Made Player class, Player Turns and Player Hands
    * Made "Shuffle", "Draw" and "Pick-Up" of Cards
    * General Code Organization
    * Made "Wildcard" method


# Repository Link:
https://github.com/ritikjoshi24/LP1RecursoProject

# Solution Architecture:
* Make a deck, give cards to players and put a card on discard deck to match (check if there is a wildcolor or other special card in beginning).
* Enters on Game loop. Checks if a player has a similar color or value, if yes, ask user to play that, if not then it ask user to pick a card.
* Before removing of a card program checks few conditions which is:
1. Checks if player plays a reverse, turns moves to left instead of right and vice versa. Checks if it is a skip , if yes , skipped the turn of next player.
2. Checks if player plays wild color card. if yes, ask user to change color then, check if it is drawfour next player draws four cards and lose his turn
3. After that it automatically remove the choosen card.
* Loop goes on untill player quit the program or it declares a winner.

## Link to Diagram:
https://viewer.diagrams.net/?highlight=0000ff&edit=_blank&layers=1&nav=1&title=Uno_Class_Diagram.drawio#R1VjbjtowEP0apPYB5FycyyMLLG21VLRIe3n0EpOkcmJkzCX9%2BjrYuQPLlmWz%2BxLFxzNjZ%2BacsZWOMYh2Y4aWwYR6mHR04O06xrCj666jiWcKJBKAhiMBn4WehLQCmIV%2FsQKBQtehh1cVQ04p4eGyCs5pHOM5r2CIMbqtmi0oqa66RD5uALM5Ik30IfR4IFFHtwv8Gw79IFtZs1w5E6HMWH3JKkAe3ZYgY9QxBoxSLt%2Bi3QCTNHdZXqTf7ZHZfGMMx%2FwcB%2FRjuHiyu8%2Fju8X90PEef2m3oGvKKBtE1uqD1WZ5kmUAeyIhakgZD6hPY0RGBXrD6Dr2cLoMEKPC5o7SpQA1Af7BnCequmjNqYACHhE1i3chf0zde6ZIrBw%2FpXM9kE0Pdyr8fpCUBlPMwghzzDIs5ixR0TQ3A9JwXdADMn6KFBH3o6Q8qseUSUkzcTT5ClrRNZvjExnPSIyYj%2FkJOz2niJAWpmI3LBF%2BDBPEw011H0iR3M%2FtCh6IF0WFV9BCa9BiyqjPUNRgR7X22yDkeLZE%2BwxsRUOo1llFxYzj3elENj9cORiaJV2yfqLUtS3EqbnKJCgJ03WulCrnQylIKAZYJQWBngGd%2F5dQqhhgljUkAlpGyxLSz5SQ3aqEmhpqkxj7SmpVZjjw1cx46ypeUB3lOqWhWDnvD3lDUP1Bd2rCl6xRXrUa59u4oOxWK1UuzjzLsMp6FQ1Bv65cX5ThkYZ%2BYaFNU6sWGprVEJKAVyu0fkDeFhF5uPHCjXj109dxfzISRpP%2Bz%2F549DszEOuVbA64fRlQURNKCGZfs%2BlnVneoh2n7ZNbdWkFg82i2QfNoduC1WrDb6lFcabanW%2B0btlX4Ge6X8Bzx3H8fPXwa9tsfjvxOm%2BQH7ZD%2F0hvf4aMGgtqdwrV7EALDgNAGpuXa9rteMexzxDMlKMHs%2FBNn%2F%2BPm8xw28B31JobFXxpZxOJXlzH6Bw%3D%3D

# Main Debated Ideas:
* How the Player and Card Classes should be structured
* How the Non-Numbered card type methods should be made and also where they should be called.
* Should we refactor and re-organize our GameManager?
* Where in general all the methods should be called