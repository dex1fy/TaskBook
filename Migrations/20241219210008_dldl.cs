using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBook.Migrations
{
    /// <inheritdoc />
    public partial class dldl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_TaskPriorities_PriorityId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_TaskStatuses_StatusId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskAssignees_Task_TaskId",
                table: "TaskAssignees");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskAssignees_Users_UserId",
                table: "TaskAssignees");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskAttachments_Task_TaskId",
                table: "TaskAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskCategoryAssignments_TaskCategories_CategoryId",
                table: "TaskCategoryAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskCategoryAssignments_Task_TaskId",
                table: "TaskCategoryAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskComments_Task_TaskId",
                table: "TaskComments");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskComments_Users_UserId",
                table: "TaskComments");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskLabelAssignments_TaskLabels_LabelId",
                table: "TaskLabelAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskLabelAssignments_Task_TaskId",
                table: "TaskLabelAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskRatings_Task_TaskId",
                table: "TaskRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskRatings_Users_UserId",
                table: "TaskRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskStatuses",
                table: "TaskStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskRatings",
                table: "TaskRatings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskPriorities",
                table: "TaskPriorities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskLabels",
                table: "TaskLabels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskLabelAssignments",
                table: "TaskLabelAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskComments",
                table: "TaskComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskCategoryAssignments",
                table: "TaskCategoryAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskCategories",
                table: "TaskCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskAttachments",
                table: "TaskAttachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskAssignees",
                table: "TaskAssignees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "TaskStatuses",
                newName: "TaskStatus");

            migrationBuilder.RenameTable(
                name: "TaskRatings",
                newName: "TaskRating");

            migrationBuilder.RenameTable(
                name: "TaskPriorities",
                newName: "TaskPrioritiy");

            migrationBuilder.RenameTable(
                name: "TaskLabels",
                newName: "TaskLabel");

            migrationBuilder.RenameTable(
                name: "TaskLabelAssignments",
                newName: "TaskLabelAssignment");

            migrationBuilder.RenameTable(
                name: "TaskComments",
                newName: "TaskComment");

            migrationBuilder.RenameTable(
                name: "TaskCategoryAssignments",
                newName: "TaskCategoryAssignment");

            migrationBuilder.RenameTable(
                name: "TaskCategories",
                newName: "TaskCategory");

            migrationBuilder.RenameTable(
                name: "TaskAttachments",
                newName: "TaskAttachment");

            migrationBuilder.RenameTable(
                name: "TaskAssignees",
                newName: "TaskAssignee");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                table: "User",
                newName: "IX_User_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskRatings_UserId",
                table: "TaskRating",
                newName: "IX_TaskRating_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskLabelAssignments_LabelId",
                table: "TaskLabelAssignment",
                newName: "IX_TaskLabelAssignment_LabelId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskComments_UserId",
                table: "TaskComment",
                newName: "IX_TaskComment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskComments_TaskId",
                table: "TaskComment",
                newName: "IX_TaskComment_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskCategoryAssignments_CategoryId",
                table: "TaskCategoryAssignment",
                newName: "IX_TaskCategoryAssignment_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskAttachments_TaskId",
                table: "TaskAttachment",
                newName: "IX_TaskAttachment_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskAssignees_UserId",
                table: "TaskAssignee",
                newName: "IX_TaskAssignee_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskStatus",
                table: "TaskStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskRating",
                table: "TaskRating",
                columns: new[] { "TaskId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskPrioritiy",
                table: "TaskPrioritiy",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskLabel",
                table: "TaskLabel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskLabelAssignment",
                table: "TaskLabelAssignment",
                columns: new[] { "TaskId", "LabelId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskComment",
                table: "TaskComment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskCategoryAssignment",
                table: "TaskCategoryAssignment",
                columns: new[] { "TaskId", "CategoryId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskCategory",
                table: "TaskCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskAttachment",
                table: "TaskAttachment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskAssignee",
                table: "TaskAssignee",
                columns: new[] { "TaskId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_TaskPrioritiy_PriorityId",
                table: "Task",
                column: "PriorityId",
                principalTable: "TaskPrioritiy",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_TaskStatus_StatusId",
                table: "Task",
                column: "StatusId",
                principalTable: "TaskStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAssignee_Task_TaskId",
                table: "TaskAssignee",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAssignee_User_UserId",
                table: "TaskAssignee",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAttachment_Task_TaskId",
                table: "TaskAttachment",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskCategoryAssignment_TaskCategory_CategoryId",
                table: "TaskCategoryAssignment",
                column: "CategoryId",
                principalTable: "TaskCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskCategoryAssignment_Task_TaskId",
                table: "TaskCategoryAssignment",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskComment_Task_TaskId",
                table: "TaskComment",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskComment_User_UserId",
                table: "TaskComment",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskLabelAssignment_TaskLabel_LabelId",
                table: "TaskLabelAssignment",
                column: "LabelId",
                principalTable: "TaskLabel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskLabelAssignment_Task_TaskId",
                table: "TaskLabelAssignment",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskRating_Task_TaskId",
                table: "TaskRating",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskRating_User_UserId",
                table: "TaskRating",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_TaskPrioritiy_PriorityId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_TaskStatus_StatusId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskAssignee_Task_TaskId",
                table: "TaskAssignee");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskAssignee_User_UserId",
                table: "TaskAssignee");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskAttachment_Task_TaskId",
                table: "TaskAttachment");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskCategoryAssignment_TaskCategory_CategoryId",
                table: "TaskCategoryAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskCategoryAssignment_Task_TaskId",
                table: "TaskCategoryAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskComment_Task_TaskId",
                table: "TaskComment");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskComment_User_UserId",
                table: "TaskComment");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskLabelAssignment_TaskLabel_LabelId",
                table: "TaskLabelAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskLabelAssignment_Task_TaskId",
                table: "TaskLabelAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskRating_Task_TaskId",
                table: "TaskRating");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskRating_User_UserId",
                table: "TaskRating");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskStatus",
                table: "TaskStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskRating",
                table: "TaskRating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskPrioritiy",
                table: "TaskPrioritiy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskLabelAssignment",
                table: "TaskLabelAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskLabel",
                table: "TaskLabel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskComment",
                table: "TaskComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskCategoryAssignment",
                table: "TaskCategoryAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskCategory",
                table: "TaskCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskAttachment",
                table: "TaskAttachment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskAssignee",
                table: "TaskAssignee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "TaskStatus",
                newName: "TaskStatuses");

            migrationBuilder.RenameTable(
                name: "TaskRating",
                newName: "TaskRatings");

            migrationBuilder.RenameTable(
                name: "TaskPrioritiy",
                newName: "TaskPriorities");

            migrationBuilder.RenameTable(
                name: "TaskLabelAssignment",
                newName: "TaskLabelAssignments");

            migrationBuilder.RenameTable(
                name: "TaskLabel",
                newName: "TaskLabels");

            migrationBuilder.RenameTable(
                name: "TaskComment",
                newName: "TaskComments");

            migrationBuilder.RenameTable(
                name: "TaskCategoryAssignment",
                newName: "TaskCategoryAssignments");

            migrationBuilder.RenameTable(
                name: "TaskCategory",
                newName: "TaskCategories");

            migrationBuilder.RenameTable(
                name: "TaskAttachment",
                newName: "TaskAttachments");

            migrationBuilder.RenameTable(
                name: "TaskAssignee",
                newName: "TaskAssignees");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameIndex(
                name: "IX_User_RoleId",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskRating_UserId",
                table: "TaskRatings",
                newName: "IX_TaskRatings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskLabelAssignment_LabelId",
                table: "TaskLabelAssignments",
                newName: "IX_TaskLabelAssignments_LabelId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskComment_UserId",
                table: "TaskComments",
                newName: "IX_TaskComments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskComment_TaskId",
                table: "TaskComments",
                newName: "IX_TaskComments_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskCategoryAssignment_CategoryId",
                table: "TaskCategoryAssignments",
                newName: "IX_TaskCategoryAssignments_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskAttachment_TaskId",
                table: "TaskAttachments",
                newName: "IX_TaskAttachments_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskAssignee_UserId",
                table: "TaskAssignees",
                newName: "IX_TaskAssignees_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskStatuses",
                table: "TaskStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskRatings",
                table: "TaskRatings",
                columns: new[] { "TaskId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskPriorities",
                table: "TaskPriorities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskLabelAssignments",
                table: "TaskLabelAssignments",
                columns: new[] { "TaskId", "LabelId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskLabels",
                table: "TaskLabels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskComments",
                table: "TaskComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskCategoryAssignments",
                table: "TaskCategoryAssignments",
                columns: new[] { "TaskId", "CategoryId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskCategories",
                table: "TaskCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskAttachments",
                table: "TaskAttachments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskAssignees",
                table: "TaskAssignees",
                columns: new[] { "TaskId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_TaskPriorities_PriorityId",
                table: "Task",
                column: "PriorityId",
                principalTable: "TaskPriorities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_TaskStatuses_StatusId",
                table: "Task",
                column: "StatusId",
                principalTable: "TaskStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAssignees_Task_TaskId",
                table: "TaskAssignees",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAssignees_Users_UserId",
                table: "TaskAssignees",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAttachments_Task_TaskId",
                table: "TaskAttachments",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskCategoryAssignments_TaskCategories_CategoryId",
                table: "TaskCategoryAssignments",
                column: "CategoryId",
                principalTable: "TaskCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskCategoryAssignments_Task_TaskId",
                table: "TaskCategoryAssignments",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskComments_Task_TaskId",
                table: "TaskComments",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskComments_Users_UserId",
                table: "TaskComments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskLabelAssignments_TaskLabels_LabelId",
                table: "TaskLabelAssignments",
                column: "LabelId",
                principalTable: "TaskLabels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskLabelAssignments_Task_TaskId",
                table: "TaskLabelAssignments",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskRatings_Task_TaskId",
                table: "TaskRatings",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskRatings_Users_UserId",
                table: "TaskRatings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}
