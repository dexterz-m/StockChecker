const api = "http://localhost:5231/items";

async function loadItems() {
  const res = await fetch(api);
  const data = await res.json();

  const list = document.getElementById("list");
  list.innerHTML = "";

  data.forEach(item => {
    const div = document.createElement("div");
    div.className = "card item";

    div.innerHTML = `
      <div>
        <strong>${item.name}</strong><br>
        <span class="badge">Qty: ${item.quantity}</span><br>
        <small>Expires: ${item.expiryDate?.split("T")[0]}</small>
      </div>
      <button onclick="deleteItem(${item.id})">🗑️</button>
    `;

    list.appendChild(div);
  });
}

async function addItem() {
  const item = {
    name: document.getElementById("name").value,
    quantity: parseInt(document.getElementById("quantity").value),
    expiryDate: document.getElementById("expiry").value
  };

  await fetch(api, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(item)
  });

  loadItems();
}

async function deleteItem(id) {
  await fetch(`${api}/${id}`, {
    method: "DELETE"
  });

  loadItems();
}

loadItems();