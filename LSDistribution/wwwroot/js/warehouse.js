class Warehouse {
    constructor(id, name) {
        this.ID = id;
        this.Name = name;
    }

    Update() {
        $.ajax({
            url: "/Warehouse/Update",
            method: "POST",
            data: this,
            success: function (data, textStatus, jqXHR) {
                switch (jqXHR.status) {
                    case 200:
                        window.location.reload();
                        break;
                    case 500:
                        alert("Server error!");
                        break;
                    default:
                        alert("Unknown error");
                        break;
                }
            }
        });
    }

    static Remove(id) {
        if (id == 0) {
            alert("Id is not valid!");
            return;
        }

        $.ajax({
            url: "/Warehosue/Remove",
            method: "POST",
            data: {
                "id": id
            },
            success: function (data, textStatus, jqXHR) {
                switch (jqXHR.status) {
                    case 200:
                        window.location.reload();
                        break;
                    case 500:
                        alert("Server error!");
                        break;
                    default:
                        alert("Unknown error");
                        break;
                }
            }
        });
    }
}