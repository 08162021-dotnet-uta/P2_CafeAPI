
//we can call an IIFE to get a list of all the customers
(function () {
	fetch("customer/Customerlist")
		.then(res => res.json())
		.then(data => {
			console.log(data)
			const lop = document.querySelector('.listofplayers');
			for (let x = 0; x < data.length; x++) {

                lop.innerHTML += `
                
                    <div class="card h-100">
                        <!-- Product details-->
                        <div class="card-body p-1">
                            <div class="text-center">
                                <!-- Product name-->
                                <p class="fw-bolder">${data[x].fname} ${data[x].lname}</p>
                               
                            </div>
                        </div>
                        
                       
                        </div>
                    </div>`;
            }
			//	lop.innerHTML += `<p>The customer is ${data[x].email} ${data[x].lname}.</p>`;
			
		});
})();

//<!-- Product price-->
//Email: ${ data[x].email }
//<!-- Product actions-->
//<div class="card-footer p-4 pt-0 border-top-0 bg-transparent">
//    <div class="text-center"><a class="btn btn-outline-dark mt-auto" href="ordersbyStore.html"><div id="${data[x].customerId}" onClick="sessionStorage.customerId=${data[x].customerId}">View Past Orders</div></a></div>


//function validateForm() {
//	let x = document.forms["myForm"]["email"].value;
//	let x = document.forms["myForm"]["password"].value;
//	fetch("customer/Customerlist")
//		.then(res => res.json())
//		.then(data => {
//			console.log(data)
//			const lop = document.querySelector('.listofplayers');
//			for (let y = 0; y < data.length; y++) {
//				data[y].email;
//				lop.innerHTML += `<p>The customer is ${data[x].fname} ${data[x].lname}.</p>`;
//			}
//		});
//	if (x == "") {
//		alert("Name must be filled out");
//		return false;
//	}
