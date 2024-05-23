class MessageHandler {
	_io;
	_rooms = { };
	_socketConnectionListener;

	constructor(io, socketConnectionListener) {
		this._io = io;
		this._socketConnectionListener = socketConnectionListener;
	}
}

module.exports = MessageHandler;