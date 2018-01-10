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
             if (lossCount >= 1) {
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




/*  Common - Display  ******/
function ChangeElementText(element, newText) {
    element.textContent = newText;
}

function ShowCardsWithCSSFilter(cardsToShow, cssFilterClass) {
    for (var i = 0; i < cardsToShow.length; i++) {
        cardsToShow[i].classList.remove(cssFilterClass);
    }
}

function HideCardsWithCSSFilter(cardsToHide, cssFilterClass) {
    for (var i = 0; i < cardsToHide.length; i++) {
        cardsToHide[i].classList.add(cssFilterClass);
    }
}

function ToggleSpacerWithCSSFilter(caller, cssFilterClass) {
    var spacerElement = caller.getElementsByClassName('game-result-spacer');
    spacerElement[0].classList.toggle(cssFilterClass);
}





/*  Filtering - Opponent  ******/
function MatchIsClanBattle(gameResultCard) {
    return GetDataValueFromMatchData(gameResultCard, "filter-isClanBattle");
}

function ShowAllOpponentsUsing(cssFilterClass, textContent) {
    var allMatches = document.getElementsByClassName("game-result-card");

    ShowCardsWithCSSFilter(allMatches, cssFilterClass);

    OpponentCleanup(textContent);
}

function ShowOnlyClanOpponentsUsing(cssFilterClass, textContent) {
    var allMatches = document.getElementsByClassName("game-result-card");
    var clanMatches = GetClanMatches(allMatches);
    var nonClanMatches = GetNonClanMatches(allMatches);

    ShowCardsWithCSSFilter(clanMatches, cssFilterClass);
    HideCardsWithCSSFilter(nonClanMatches, cssFilterClass);

    OpponentCleanup(textContent);
}

function ShowOnlyNonClanOpponentsUsing(cssFilterClass, textContent) {
    var allMatches = document.getElementsByClassName("game-result-card");
    var clanMatches = GetClanMatches(allMatches);
    var nonClanMatches = GetNonClanMatches(allMatches);

    ShowCardsWithCSSFilter(nonClanMatches, cssFilterClass);
    HideCardsWithCSSFilter(clanMatches, cssFilterClass);

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

function ShowAllDatesUsing(cssFilterClass, textContent) {

    var allMatches = document.getElementsByClassName("game-result-card");


    var matchesToShow = GetAllMatchesAfterDate(allMatches, new Date(2015, 9, 26));

    ShowCardsWithCSSFilter(matchesToShow, cssFilterClass);

    DateCleanup(textContent);
}

function ShowOnlyDatesForLast30DaysUsing(cssFilterClass, textContent) {
    var allMatches = document.getElementsByClassName("game-result-card");

    var thirtyDayDate = MakeDateXDaysInPast(30);

    var matchesToShow = GetAllMatchesAfterDate(allMatches, thirtyDayDate);
    var matchesToHide = GetAllMatchesBeforeDate(allMatches, thirtyDayDate);

    ShowCardsWithCSSFilter(matchesToShow, cssFilterClass);
    HideCardsWithCSSFilter(matchesToHide, cssFilterClass);

    DateCleanup(textContent);
}

        function MakeDateXDaysInPast(daysInPast) {
            var today = new Date();
            var priorDate = new Date().setDate(today.getDate() - daysInPast);
        
            return new Date(priorDate);
        }

    function DateCleanup(textToReplace) {
        var dateButton = document.getElementById("date-filter-btn");
        ChangeElementText(dateButton, textToReplace);
    
        RecalculateAggregateStats();
    }
    
    
    function GetAllMatchesAfterDate(gameResultCardsToSearch, chosenDate) {
        
        var matchesAfteChosenDate = [];
    
        for (var i = 0; i < gameResultCardsToSearch.length; i++) {
            var matchDate = new Date(GetMatchDate(gameResultCardsToSearch[i]));
    
            if (matchDate.getTime() > chosenDate.getTime()) {
                matchesAfteChosenDate.push(gameResultCardsToSearch[i]);
            }
        }

        return matchesAfteChosenDate;
    }

    function GetAllMatchesBeforeDate(gameResultCardsToSearch, chosenDate) {

        var matchesBeforeChosenDate = [];

        for (var i = 0; i < gameResultCardsToSearch.length; i++) {
            var matchDate = new Date(GetMatchDate(gameResultCardsToSearch[i]));

            if (matchDate.getTime() <= chosenDate.getTime()) {
                matchesBeforeChosenDate.push(gameResultCardsToSearch[i]);
            }
        }

        return matchesBeforeChosenDate;
    }




/*  Filtering - Mode  *******/
function GetGameMode(gameResultCard) {
    return GetDataValueFromMatchData(gameResultCard, "filter-gameMode");
}

function ShowAllModesUsing(cssFilterClass, textContent) {

    var allMatches = document.getElementsByClassName("game-result-card");

    var matchesToShow = allMatches;

    ShowCardsWithCSSFilter(matchesToShow, cssFilterClass);

    ModeCleanup(textContent);
}

function ShowOnlyArenaModesUsing(cssFilterClass, textContent) {
    ShowMatchesWithSingleModeMatching("Arena", cssFilterClass, textContent);}

function ShowOnlyWarzoneModesUsing(cssFilterClass, textContent) {
    ShowMatchesWithSingleModeMatching("Warzone", cssFilterClass, textContent);
}

        function ShowMatchesWithSingleModeMatching(modeToMatch, cssFilterClass, textContent) {
            var allMatches = document.getElementsByClassName("game-result-card");
        
            var matchesToShow = GetMatchesWithModeMatching(allMatches, modeToMatch);
            var matchesToHide = GetMatchesWithModeNotMatching(allMatches, modeToMatch);
        
            ShowCardsWithCSSFilter(matchesToShow, cssFilterClass);
            HideCardsWithCSSFilter(matchesToHide, cssFilterClass);
        
            ModeCleanup(textContent);
        }

    function ModeCleanup(textToReplace) {
        var modeButton = document.getElementById("mode-filter-btn");
        ChangeElementText(modeButton, textToReplace);
    
        RecalculateAggregateStats();
    }

    function GetMatchesWithModeMatching(gameResultCardsToSearch, modeToMatch) {
        var matchesMatchingMode = [];

        for (var i = 0; i < gameResultCardsToSearch.length; i++) {
            var mode = GetGameMode(gameResultCardsToSearch[i]);

            if (mode === modeToMatch) {
                matchesMatchingMode.push(gameResultCardsToSearch[i]);
            }
        }

        return matchesMatchingMode;
    }

    function GetMatchesWithModeNotMatching(gameResultCardsToSearch, modeToMatch) {
        var matchesNotMatchingMode = [];

        for (var i = 0; i < gameResultCardsToSearch.length; i++) {
            var mode = GetGameMode(gameResultCardsToSearch[i]);

            if (! (mode === modeToMatch)) {
                matchesNotMatchingMode.push(gameResultCardsToSearch[i]);
            }
        }

        return matchesNotMatchingMode;
    }