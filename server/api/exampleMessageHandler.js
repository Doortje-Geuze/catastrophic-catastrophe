const MessageHandler = require("./messageHandler");

class ExampleMessageHandler extends MessageHandler
{
    constructor(io, rooms, socketConnectionListener) {
        super(io, rooms, socketConnectionListener);
    }

    handleIncomingMessages(socket) {
        this.#sendMatchData(socket)
    }

    #sendPlayerData(socket) {
        socket.on("Player", (data) => {
            this._socketConnectionListener.executePreparedQuery("INSERT INTO player (Player_Session) VALUES (? , ?, ?, ?)", [data.totalWavesSurvived, data.killedBy, data.kills, data.healthLeft])
            console.log(data);
        });
    }

    #sendMatchData(socket) {
        socket.on("Match", (data) => {
            this._socketConnectionListener.executePreparedQuery("INSERT INTO `match` (TotalWavesSurvived, KilledBy, Kills, HealthLeft) VALUES (? , ?, ?, ?)", [data.totalWavesSurvived, data.killedBy, data.kills, data.healthLeft])
            console.log(data);
        });
    }

    // #sendMatchData(socket) {
    //     socket.on("Inventory", (data) => {
    //         this._socketConnectionListener.executePreparedQuery("INSERT INTO `match` (TotalWavesSurvived, KilledBy, Kills, HealthLeft) VALUES (? , ?, ?, ?)", [data.totalWavesSurvived, data.killedBy, data.kills, data.healthLeft])
    //         console.log(data);
    //     });
    // }
}

module.exports = ExampleMessageHandler;