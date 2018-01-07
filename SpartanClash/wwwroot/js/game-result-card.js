/* When the user clicks on the button,
toggle between hiding and showing the dropdown content */
function showDropdownContent(id) {
    document.getElementById(id).classList.toggle("show");
}

// Close the dropdown menu if the user clicks outside of it
window.onclick = function (event) {
    if (!event.target.matches('.filter-btn')) {

        var dropdowns = document.getElementsByClassName("dropdown-content");
        var i;
        for (i = 0; i < dropdowns.length; i++) {
            var openDropdown = dropdowns[i];
            if (openDropdown.classList.contains('show')) {
                openDropdown.classList.remove('show');
            }
        }
    }
}

/******  Filtering - Common  ******/

function RecalculateAggregateStats() {

}

function showCardsWithCSSFilter(cardsToShow, cssFilterClass) {
    for (var i = 0; i < cardsToShow.length; i++) {
        cardsToShow[i].classList.remove(cssFilterClass);
    }
}

function hideCardsWithCSSFilter(cardsToHide, cssFilterClass) {
    for (var i = 0; i < cardsToHide.length; i++) {
        cardsToHide[i].classList.add(cssFilterClass);
    }
}

function ChangeButtonTextByID(button, newText) {
    button.textContent = newText;
}


/******  Filtering - Opponent  ******/


function showAllOpponentsUsing(cssFilterClass, textContent) {
    var clanMatches = GetClanMatches();
    var nonClanMatches = GetNonClanMatches();

    showCardsWithCSSFilter(clanMatches, cssFilterClass);
    showCardsWithCSSFilter(nonClanMatches, cssFilterClass);

    OpponentCleanup(textContent);
}

function showOnlyClanOpponentsUsing(cssFilterClass, textContent) {
    var clanMatches = GetClanMatches();
    var nonClanMatches = GetNonClanMatches();

    showCardsWithCSSFilter(clanMatches, cssFilterClass);
    hideCardsWithCSSFilter(nonClanMatches, cssFilterClass);

    OpponentCleanup(textContent);
}

function showOnlyNonClanOpponentsUsing(cssFilterClass, textContent) {
    var clanMatches = GetClanMatches();
    var nonClanMatches = GetNonClanMatches();

    showCardsWithCSSFilter(nonClanMatches, cssFilterClass);
    hideCardsWithCSSFilter(clanMatches, cssFilterClass);

    OpponentCleanup(textContent);
}

    function OpponentCleanup(textToReplace) {
        var opponentButton = document.getElementById("opponent-filter-btn");
        ChangeButtonTextByID(opponentButton, textToReplace);
    
        RecalculateAggregateStats();
    }
       

    function GetClanMatches() {
        var clanMatchHeaderElements = document.getElementsByClassName('enemy-clan-link');
        return GetParentGameResultCards(clanMatchHeaderElements);
    }
    
    function GetNonClanMatches() {
        var nonClanHeaderElements = document.getElementsByClassName('non-clan-header');
        return GetParentGameResultCards(nonClanHeaderElements);
    }
    
        function GetParentGameResultCards(childNodeList) {
        
            var matchingGameResultCards = [childNodeList.length];
        
            for (var i = 0; i < childNodeList.length; i++) {
                matchingGameResultCards[i] = childNodeList[i].parentElement.parentElement;
            }
        
            return matchingGameResultCards;
        }

/******  Filtering - Date  ******/



/******  Filtering - Mode  ******/
