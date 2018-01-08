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
};

/*  Filtering - Common  ******/

function RecalculateAggregateStats() {
    var winCountElement = document.getElementById("winCount");
    var lossCountElement = document.getElementById("lossCount");
    var winRatioElement = document.getElementById("winRatio");


    var allCards = document.getElementsByClassName("game-result-card");
    //TODO Filter Cards to only visible elements;

    var winCounter = 0;
    var lossCounter = 0;
    var winRatioCalculated = "X.XX";

    for (var i = 0; i < allCards.length; i++){

        if (MatchIsWin(allCards[i]) === "True")
        {
            winCounter++;
        }
        else {
            lossCounter++;
        }
    }

    ChangeElementText(winCountElement, "TODO");
    ChangeElementText(lossCountElement, "TODO");
    ChangeElementText(winRatioElement, "TODO");
}

            function MatchIsWin(gameResultCard) {
                return GetDataValueFromMatchData(gameResultCard, "filter-isWin");
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

function ChangeElementText(button, newText) {
    button.textContent = newText;
}


function GetDataValueFromMatchData(gameResultCard, dataElementToSearch)
{
    var matchData = GetMatchDataFromCard(gameResultCard);
    var dataElement = GetDataElementFromMatchData(matchData, dataElementToSearch);

    return dataElement.textContent;
}

        function GetMatchDataFromCard(gameResultCard) {
            var matchData = gameResultCard.getElementsByClassName("match-filter-data")[0];
            return matchData;
        }
        
        function GetDataElementFromMatchData(matchData, dataElementToSearch) {
            var dataElement = matchData.getElementsByClassName(dataElementToSearch)[0];
            return dataElement;
        }





/*  Filtering - Opponent  ******/
function MatchIsClanBattle(gameResultCard) {
    return GetDataValueFromMatchData(gameResultCard, "filter-isClanBattle");
}



function showAllOpponentsUsing(cssFilterClass, textContent) {
    var allMatches = document.getElementsByClassName("game-result-card");

    var clanMatches = GetClanMatches(allMatches);
    var nonClanMatches = GetNonClanMatches(allMatches);

    showCardsWithCSSFilter(clanMatches, cssFilterClass);
    showCardsWithCSSFilter(nonClanMatches, cssFilterClass);

    OpponentCleanup(textContent);
}

function showOnlyClanOpponentsUsing(cssFilterClass, textContent) {
    var allMatches = document.getElementsByClassName("game-result-card");

    var clanMatches = GetClanMatches(allMatches);
    var nonClanMatches = GetNonClanMatches(allMatches);

    showCardsWithCSSFilter(clanMatches, cssFilterClass);
    hideCardsWithCSSFilter(nonClanMatches, cssFilterClass);

    OpponentCleanup(textContent);
}

function showOnlyNonClanOpponentsUsing(cssFilterClass, textContent) {
    var allMatches = document.getElementsByClassName("game-result-card");

    var clanMatches = GetClanMatches(allMatches);
    var nonClanMatches = GetNonClanMatches(allMatches);

    showCardsWithCSSFilter(nonClanMatches, cssFilterClass);
    hideCardsWithCSSFilter(clanMatches, cssFilterClass);

    OpponentCleanup(textContent);
}

    function OpponentCleanup(textToReplace) {
        var opponentButton = document.getElementById("opponent-filter-btn");
        ChangeElementText(opponentButton, textToReplace);
    
        RecalculateAggregateStats();
    }
       

    function GetClanMatches(gameResultCardsToSearch) {
        var clanMatches = [];

        for (var i = 0; i < gameResultCardsToSearch.length; i++) {
            if ( MatchIsClanBattle(gameResultCardsToSearch[i]) === "True" ) {
                clanMatches.push(gameResultCardsToSearch[i]);
            }
        }

        return clanMatches;
    }
    
    function GetNonClanMatches(gameResultCardsToSearch) {
        var nonClanMatches = [];

        for (var i = 0; i < gameResultCardsToSearch.length; i++) {
            if (MatchIsClanBattle(gameResultCardsToSearch[i]) === "False" ) {
                nonClanMatches.push(gameResultCardsToSearch[i]);
            }
        }

        return nonClanMatches;
    }


/*  Filtering - Date  ******/
function GetMatchDate(gameResultCard) {
    return GetDataValueFromMatchData(gameResultCard, "filter-matchDate");
}


/*  Filtering - Mode  *******/
function GetMatchDate(gameResultCard) {
    return GetDataValueFromMatchData(gameResultCard, "filter-matchDate");
}