window.addEventListener("load", addhandlerorsomething);

function addhandlerorsomething() {

    if (sessionStorage.getItem("guid") === null) {
        sessionStorage.setItem('guid', CreateGuid())
    }

    const addtocart = document.querySelector(".jsonpostaddtocart");
    addtocart.addEventListener('click', (e) => {
       
        var buttonclicked = event.target;
        console.log(buttonclicked);
        if (buttonclicked.classList.contains('outofstock')) {
            console.log(true);
            return;
        }
        var n = sessionStorage.getItem('counter');
        if (n === null) {
            n = 1;
        } else {
            n++;
        }

        sessionStorage.setItem("counter", n);




 
        var user = JSON.parse(sessionStorage.user);
        //var guid = JSON.parse(localStorage.guid);

        var cart = {
            OrderId: sessionStorage.guid,
            CustomerId: user.customerId,
            StoreProductId:1,
            ProductId: sessionStorage.getItem('productid'),
            StoreId: sessionStorage.StoreId,
            OrderDate: formatAMPM(new Date),
            StoreName: sessionStorage.storeName,
            ProductPrice: sessionStorage.ProductPrice,
            ProductName: sessionStorage.ProductName
        }
        if (sessionStorage.getItem('productid' + sessionStorage.getItem('productid')) != null) {
            var numberparsed = parseInt(sessionStorage.getItem('productid' + sessionStorage.getItem('productid'))) + 1;
            sessionStorage.setItem('productid' + sessionStorage.getItem('productid'), numberparsed);
        }
        else
            sessionStorage.setItem('productid' + sessionStorage.getItem('productid'), 1);

        var record = JSON.stringify(cart);

        localStorage.setItem('cart'+sessionStorage.counter, record);
   

    })
        sessionStorage.removeItem('ProductName');
         sessionStorage.removeItem('ProductPrice');
};





function CreateGuid() {
    function _p8(s) {
        var p = (Math.random().toString(16) + "000000000").substr(2, 8);
        return s ? "-" + p.substr(0, 4) + "-" + p.substr(4, 4) : p;
    }
    return _p8() + _p8(true) + _p8(true) + _p8();
}
function formatAMPM(date) {
    var hours = date.getHours();
    var minutes = date.getMinutes();
    var ampm = hours >= 12 ? 'pm' : 'am';
    hours = hours % 12;
    hours = hours ? hours : 12; // the hour '0' should be '12'
    minutes = minutes < 10 ? '0' + minutes : minutes;
    var strTime = hours + ':' + minutes + ' ' + ampm;
    return strTime;
}