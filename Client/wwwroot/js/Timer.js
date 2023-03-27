
    function startTimer(timerElem) {
        var timerValue = parseInt(timerElem.innerHTML);
    var interval = setInterval(function() {
            if (timerValue > 0) {
        timerValue--;
    timerElem.innerHTML = timerValue;
            } else {
        clearInterval(interval);
            }
        }, 1000);
    }