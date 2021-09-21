window.addEventListener("load", () => loadPre(), false);

async function loadPre () {
	console.log(sessionStorage);
	//fetch("Products/Productlist")
	let user = JSON.parse(sessionStorage.getItem('user'));
	fetch(`/ViewAll/customerpastorders/${user.customerId}`)
		.then(res => res.json())
		.then(data => {
			console.log(data)
			const lop = document.querySelector('.customerpastorderPerstore');
			var totalprice = 0;

			for (let x = 0; x < sessionStorage.counter; x++) {
				var user = JSON.parse(localStorage.getItem('cart' + parseInt(x+1)));
				console.log(user);
				totalprice += parseFloat(user.ProductPrice,2);
				lop.innerHTML += `
					<tr >
						<td>${user.OrderId}</td>
						<td>${user.StoreName}</td>
						<td>${user.ProductName}</td>
						<td>$${user.ProductPrice}</td>
					</tr>`;
			}
			lop.innerHTML += `
				<tr >
						<td></td>
						<td></td>
						<td>Total Spent:</td>
						<td><Strong> $${totalprice.toFixed(2)}</Strong></td>
					</tr>`;
	
		});

};

