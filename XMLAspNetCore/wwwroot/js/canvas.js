function init()
{
    var canvas = document.getElementById("MyCanvas");
    if (canvas.getContext) {
        var ctx = canvas.getContext("2d");
        ctx.fillStyle = "#F30";
        ctx.fillRect(0, 0, canvas.window, canvas.height);
        ctx.clearRect(800, 200, 500, 500);
    }
}
onload = init;
