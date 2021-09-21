window.addEventListener("load", () => loadPre(), false);

async function loadPre() {
	console.log(sessionStorage);
	//let user = JSON.parse(sessionStorage.getItem('user'));
	//fetch("Products/Productlist")
	fetch(`/Stores/pastordersbystore/${sessionStorage.StoreId}`)
		.then(res => res.json())
		.then(data => {
			console.log(data)
			const lop = document.querySelector('.storepastorderPerstore');
			var totalprice = 0;

			for (let x = 0; x < data.length; x++) {
				totalprice += data[x].productPrice;
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
	sessionStorage.removeItem('StoreId2');
};
	