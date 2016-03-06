$(function () {
    var global = {};
    function MessageContainer(container) {
        this.container = $("#"+container);
        this.removePlayer = function (player) {
            $("#auto_gen_" + player.Name).remove();
        }
        var that = this;
        this.addPlayers = function (players) {
            players.forEach(that.addPlayer);
        }
        this.addPlayer = function (player) {
            if (!$("#auto_gen_" + player.Name).length) {
                that.container.append("<div class='row' id='auto_gen_" + player.Name + "'>" + player.Name + "</div>");
            }
        };

    }
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
    // Start the connection.
    global.name = $('#displayname').val();
    var playersList = new MessageContainer("players");
    $.connection.hub.start().done(function () {
        chat.server.wellcome({ Name: global.name, Color: "#ff0" }).done(function (players) {
            playersList.addPlayers(players);
            console.log("wellcome done", players);
        });
    });
    $('#sendmessage').click(function () {
            chat.server.send($('#displayname').val(), $('#message').val(), $("#who").val());
            // Clear text box and reset focus for next comment.
            $('#message').val('').focus();
    });
    chat.client.addPlayer = function (player) {
        playersList.addPlayer(player);
        console.log("player added", player);
    };
    chat.client.removePlayer = function (player) {
        playersList.removePlayer(player);
        console.log("player removed", player);
    }
});