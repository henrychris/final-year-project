window.ScrollToBottom = (elementName) => {
    element = document.getElementById(elementName);
    element.scrollTop = element.scrollHeight - element.clientHeight;
}

// TODO use alternate solution
// just auto scroll to the chat box so user starts typing.