const loginform = document.querySelector(".loginform");
loginform.addEventListener('submit', (e) => {
    e.preventDefault();
    const fname = loginform.fname.value;
    const lname = loginform.lname.value;
    
    //GET fetch request
    fetch(`customer/login/${fname}/${lname}`)
    .then(res => {
            if (!res.ok) {
                console.log('unable to login the user')
                throw new Error(`Network response was not ok (${res.status})`);
            }
            return res.json();
        })
        .then(res => {
            sessionStorage.setItem('user', JSON.stringify(res));//, json.stringify(res));
            let user = sessionStorage.getItem('user');
            console.log(sessionStorage.user);
            location.href = "Store.html";
            //There I will store the if, if found, in the sesſionstorage
        })
        .catch(err => console.log(`There was an error ${err}`));
});


function Login() {
    location.href = "login.html";
}

function Register() {
    location.href = "register.html";
}

function AddtoCart() {
    location.href = "Cart.html";
}