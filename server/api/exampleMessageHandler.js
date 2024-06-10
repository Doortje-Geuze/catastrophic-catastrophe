const MessageHandler = require("./messageHandler");

class ExampleMessageHandler extends MessageHandler
{
    constructor(io, rooms, socketConnectionListener) {
        super(io, rooms, socketConnectionListener);
    }

    handleIncomingMessages(socket) {
        this.#sendMatchData(socket)
    }

    #sendMatchData(socket) {
        socket.on("Example", (data) => {
            this._socketConnectionListener.executePreparedQuery("INSERT INTO `match` (TotalWavesSurvived, KilledBy, Kills, HealthLeft) VALUES (? , ?, ?, ?)", [data.TotalWavesSurvived, data.KilledBy, data.Kills, data.HealthLeft])
            console.log(data);
        });
    }
}

module.exports = ExampleMessageHandler;