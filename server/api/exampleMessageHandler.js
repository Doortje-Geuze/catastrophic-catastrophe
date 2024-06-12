const MessageHandler = require("./messageHandler");

class ExampleMessageHandler extends MessageHandler
{
    constructor(io, rooms, socketConnectionListener) {
        super(io, rooms, socketConnectionListener);
    }

    handleIncomingMessages(socket) {
        this.#handleIncomingPlayerChatMessages(socket)
    }

    #handleIncomingPlayerChatMessages(socket) {
        socket.on("Example", async(data) => {
            this._socketConnectionListener.executePreparedQuery("INSERT INTO `match` (TotalWavesSurvived, KilledBy, Kills, HealthLeft) VALUES (? , ?, ?, ?)", [8, "rat", 4, 4])
            console.log(data);
        });
    }
}

module.exports = ExampleMessageHandler;