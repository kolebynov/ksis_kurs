import React from "react";
import BaseModelSchemaPage from "../BaseModelSchemaPage/BaseModelSchemaPage.jsx";
import CommentaryList from "../../CommentaryList/CommentaryList.jsx";
import "./NoteModelPage.css";

class NoteModelPage extends BaseModelSchemaPage {
    _renderBody() {
        return (
            <div>
                {this.renderEditComponent("name")}
                {this.renderEditComponent("description")}
                {this.renderEditComponent("category")}
                <div className="commentaries-wrapper">
                    <CommentaryList noteId={this.props.primaryColumnValue} />
                </div>
            </div>
        );
    }
}

export default NoteModelPage;