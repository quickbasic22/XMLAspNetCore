
function changeXmlPage(select)
{
    document.getElementById('_Layout').submit();
    var url = select.value;
    // Redirect without leaving a directory in the URL
    window.location.href = url;
}

$(document).ready(function()
{
    $('.heart').hover(function()
    {
        $(this).css('transition-timing-function', 'steps(5)');
        $(this).css('transition-duration', '0.4s');
        $(this).css('transform', 'scale(1.2)');
    }, function ()
    {
        $(this).css('transition-timing-function', 'cubic-bezier(0.42,0,0.58,1)');
        $(this).css('transition-duration', '0.6s');
        $(this).css('transform', 'scale(1)');
    });
});