/// <reference path="jQuery-3.6.0.js" />

var $WS;

var $WSF = {
	setConnectionState: function(state) {
		try { $('#connectionState').html($WSF.stateSpan(state)); } catch { }
	},
	stateOn: "<span class='state sOn'>online</span>",
	stateOff: "<span class='state sOff'>offline</span>",
	stateSpan: function(state) { if (state) return $WSF.stateOn; return $WSF.stateOff; }
};

function reload() {
	location.reload();
}

class XMLNavigator {
	XMLNavigator() { }
	selectNode(node, s) { return node.querySelector(s) }
	selectNodes(node, s) { return node.querySelectorAll(s) }
}
var NAV = new XMLNavigator();

/** @param {XMLDocument} doc */
function alertXML(doc) {
	var s = new XMLSerializer().serializeToString(doc);
	//NAV.selectNodes(doc, ":scope > :last-child").forEach(function (value, key, parentList) {
	//	s += new XMLSerializer().serializeToString(value);
	//});
	alert(s);
}

function on_Message(msg) {
	try {
		alert("len = " + msg.length);
		var parser = new DOMParser();
		var doc = parser.parseFromString(msg, "application/xml");
		var errorNode = doc.querySelector("parsererror");
		if (errorNode != null) alert("error while parsing <<" + msg + ">>");
		else alertXML(doc);
	}
	catch(e) { alert("got Message: " + e + ": " + msg); }
}

function connect() {
	var url = document.URL.replace("https:", "wss:");
	if (url.endsWith("/")) url += "Index.ashx";
	$WS = new WebSocket(url);
	$WS.onopen = function (evt) { $WS.send("ok"); $WSF.setConnectionState(true); }
	$WS.onclose = function (evt) { $WSF.setConnectionState(false); setTimeout(reload, 333); }
	$WS.onmessage = function (evt) { on_Message(evt.data); }
}
$(function () { connect() })

/** @param {HTMLElement} btn */
function clickedButton(btn) {
	//$WS.send(btn.id + " " + btn.classList);
	var sel = btn.classList.contains("state_selected");
	btn.classList.remove("state_selected");
	btn.classList.remove("state_unselected");
	if (sel) btn.classList.add("state_unselected");
	if (!sel) btn.classList.add("state_selected");

	$WS.send("<test><v1>fv1</v1><v2><vvv>fv2v</vvv><vvw>fv2w</vvw></v2></test>");
}
