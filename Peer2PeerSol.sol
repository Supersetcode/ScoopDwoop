// SPDX-License-Identifier: MIT
pragma solidity ^0.8.0;

contract PeerToPeerContract {
    mapping(address => uint256) public userIDs;

    event ConnectionRequest(address from, address to, uint256 requestID);

    function setUserID(uint256 _userID) external {
        userIDs[msg.sender] = _userID;
    }

    function requestConnection(address _to) external {
        uint256 requestID = uint256(keccak256(abi.encodePacked(msg.sender, _to, block.timestamp)));
        emit ConnectionRequest(msg.sender, _to, requestID);
    }
}
