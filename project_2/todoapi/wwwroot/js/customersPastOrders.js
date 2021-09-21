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

			for (let x = 0; x < data.length; x++) {
				totalprice += data[x].productPrice;
				console.log(data[x]);
				lop.innerHTML += `
					<tr >
						<td>${data[x].orderId}</td>
						<td>${data[x].storeName}</td>
							<td>${data[x].orderDate}</td>
			<td>${data[x].productName}</td>
						<td>${data[x].productDescription}</td>
						<td>$${data[x].productPrice}</td>
					</tr>`;
			}
			lop.innerHTML += `
				<tr >
						<td></td>
						<td></td>
						<td></td>
						
						<td></td>
						<td>Total Spent:</td>
						<td><Strong> $${totalprice}</Strong></td>
					</tr>`;

		});

};