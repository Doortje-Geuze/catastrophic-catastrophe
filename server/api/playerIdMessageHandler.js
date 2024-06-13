const MessageHandler = require("./messageHandler");

class playerIdMessageHandler extends MessageHandler
{
    constructor(io, rooms, socketConnectionListener) {
        super(io, rooms, socketConnectionListener);
    }

    handleIncomingMessages(socket) {
        this.#sendMatchData(socket)
    }

    #sendMatchData(socket) {
        socket.on("Match", (data) => {
            this._socketConnectionListener.executePreparedQuery("INSERT INTO `match` (TotalWavesSurvived, KilledBy, Kills, HealthLeft) VALUES (? , ?, ?, ?)", [data.totalWavesSurvived, data.killedBy, data.kills, data.healthLeft])
            console.log(data);
        });
    }
}

module.exports = ExampleMessageHandler;