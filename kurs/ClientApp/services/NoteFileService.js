class NoteFileService {
    uploadFiles(noteId, files) {
        return new Promise(());
        const xhr = new XMLHttpRequest();
        const formData = new FormData();
        formData.append("files", files);
        xhr.open("POST", `/api/notes/${noteId}/uploadFiles`);
        xhr.send(formData);
    }
}

export default new NoteFileService();