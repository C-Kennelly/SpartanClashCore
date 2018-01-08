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


/*  Common - ******/
function MatchIsWin(gameResultCard) {
    return GetDataValueFromMatchData(gameResultCard, "filter-isWin");
}
    /*  Common - Recalculation  ******/
    
    function RecalculateAggregateStats() {
        var winCounter = 0;
        var lossCounter = 0;
        var allCards = document.getElementsByClassName("game-result-card");
    
        for (var i = 0; i < allCards.length; i++){
    
            if (MatchIsVisible(allCards[i]))
            {
                if (MatchIsWin(allCards[i]) === "True") {
                    winCounter++;
                }
                else {
                    lossCounter++;
                }
            }
        }
    
        var winRatioText = CalculateWinRatioText(winCounter, lossCounter);
    
        UpdateWinLossRatioText(winCounter.toString(), lossCounter.toString(), winRatioText);
    
    }

            function MatchIsVisible(gameResultCard) {
            
                if (gameResultCard.classList.contains("opponent-hidden")
                    || gameResultCard.classList.contains("mode-hidden")
                    || gameResultCard.classList.contains("date-hidden")
                ) {
                    return false;
                }
                else {
                    return true;
                }
}

            function CalculateWinRatioText(winCount, lossCount) {
                var winRatio = "--";
                if (lossCount > 1) {
                    winRatio = (winCount / lossCount).toFixed(2).toString();
                }

                return winRatio;
            }

            function UpdateWinLossRatioText(winText, lossText, ratioText) {
                var winCountElement = document.getElementById("winCount");
                var lossCountElement = document.getElementById("lossCount");
                var winRatioElement = document.getElementById("winRatio");
            
                ChangeElementText(winCountElement, winText.toString());
                ChangeElementText(lossCountElement, lossText.toString());
                ChangeElementText(winRatioElement, ratioText);
            }

            




    /*  Common - MatchData  ******/
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



    /*  Common - Say  ******/
    function ChangeElementText(element, newText) {
        element.textContent = newText;
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