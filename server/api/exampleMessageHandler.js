const MessageHandler = require("./messageHandler");

class ExampleMessageHandler extends MessageHandler
{
    #databaseConnector;

    constructor(io, rooms, socketConnectionListener, databaseConnector) {
        super(io, rooms, socketConnectionListener);
        this.#databaseConnector = databaseConnector;
    }

    handleIncomingMessages(socket) {
        this.#handleIncomingPlayerChatMessages(socket)
    }

    #handleIncomingPlayerChatMessages(socket) {
        socket.on("Example", (data) => {
            console.log(data);
        });

        this.#databaseConnector.executePreparedQuery(
            "INSERT INTO `match` (TotalWavesSurvived, KilledBy, Kills, HealthLeft) VALUES (?, ?, ?, ?)", 
            [6, 'bullet', 6, 6], 
        );
    }
}

module.exports = ExampleMessageHandler;