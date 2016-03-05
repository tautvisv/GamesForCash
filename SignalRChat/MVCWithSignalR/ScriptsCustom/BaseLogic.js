var globalItem = {};
var Utils = {};

$(document).ready(function () {
    Utils.GameLogic = (function() {

        function randomHexColor() {
            return "#" + ((1 << 24) * Math.random() | 0).toString(16);
        }

        function createPlayerItem(name, color) {
            var item = $("<div class='item' id='item_" + name + "'><span>" + name + "</span>" +
                '<div class="ghost blinky" style="background:' + color + '">' +
                '<div class="eyes"><div class="eye leftEye"><div class="iris"></div></div><div class="eye rightEye"><div class="iris"></div></div></div>' +
                    '<div class="ghostTail" style="  background:linear-gradient(-60deg, transparent 75%, ' + color + ' 75%) 0 50%,linear-gradient( 60deg, transparent 75%, ' + color + ' 75%) 0 50%;"></div>' +
                '</div>' +
                "</div>");
            return item;
        }

        return {
            randomHexColor: randomHexColor,
            createPlayerItem: createPlayerItem
        }
    })();

    function initialise(global, utils) {
        var items = {};
        global.items = items;
        // Declare a proxy to reference the hub.
        var chat = $.connection.chatHub;

        // Create a function that the hub can call to broadcast messages.
        chat.client.broadcastMessage = function (message) {
            // Html encode display name and message.
            var encodedName = $('<div />').text(message.Name).html();
            var encodedMsg = $('<div />').text(message.Message).html();
            var encodedCount = $('<div />').text("Count: " + message.Count).html();
            // Add the message to the page.
            $('#discussion').append('<li><strong>' + encodedName
                + '</strong>:&nbsp;&nbsp;' + encodedMsg + '</strong>:&nbsp;&nbsp;' + encodedCount + '</li>');
        };
        // Get the user name and store it to prepend to messages.
        $('#displayname').val(prompt('Enter your name:', ''));
        // Set initial focus to message input box.
        $('#message').focus();
        global.name = $('#displayname').val();

        global.container = $(".game-container");
        // Start the connection.
        $.connection.hub.start().done(function () {
            $('#sendmessage').click(function () {
                // Call the Send method on the hub.
                chat.server.send($('#displayname').val(), $('#message').val());
                // Clear text box and reset focus for next comment.
                $('#message').val('').focus();
            });
        });
    };

    $(document).ready(initialise(globalItem, Utils.GameLogic));
});