var Noticias = {
    Salvar: function () {
        var tags = [];
        $("input[name='tagIds']:checked").each(function () {
            tags.push($(this).val());
        });

        var noticia = {
            Id: $("#Id").val(),
            Titulo: $("#Titulo").val(),
            Texto: $("#Texto").val(),
            TagsIds: tags
        };


        $.ajax({
            url: "/Noticia/Salvar",
            method: "POST",
            contentType: "application/json",
            data: JSON.stringify(noticia),
            success: function (res) {
                if (res.success) {
                    window.location.href = "/Noticia/Index";
                }
            },
            error: function (xhr) {
                alert("Erro ao salvar notícia.");
            }
        });
    },
    Deletar: function (id) {
        if (!confirm("Tem certeza que deseja excluir esta notícia?")) {
            return;
        }

        $.ajax({
            url: "/Noticia/Deletar/" + id,
            method: "POST",
            success: function (res) {
                if (res.success) {
                    window.location.href = "/Noticia/Index";
                }
            },
            error: function (xhr) {
                alert("Erro ao excluir notícia.");
            }
        });
    }
}
