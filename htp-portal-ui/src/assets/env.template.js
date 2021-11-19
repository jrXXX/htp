(function(window) {
    window.env = window.env || {};
  
    // Environment variables
    window["env"]["backendUrl"] = "${BACKEND_URL}";
    window["env"]["ownUrl"] = "${OWN_URL}";
  })(this);