function UnityProgress (dom) {

  this.SetProgress = function (progress) {}

  this.SetMessage = function (message) {}

  this.Clear = function() {
    window.setTimeout(function() {
      document.getElementById("loading").className = "ready";
    }, 2000)
  }

  this.Update = function() {}

  this.Update();
}