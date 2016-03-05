$(function () {
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
    $.connection.hub.start().done(function () {
        $('#sendmessage').click(function () {
            // Call the Send method on the hub.
            chat.server.send($('#displayname').val(), $('#message').val());
            // Clear text box and reset focus for next comment.
            $('#message').val('').focus();
        });
    });
});