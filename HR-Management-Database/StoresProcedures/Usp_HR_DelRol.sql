﻿--IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Usp_HR_DelRol') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
--    DROP PROCEDURE Usp_HR_DelRol;
--GO
/*
-- ===================================================================================== --
--	Details			: Delete the data of a determined role.
--	Author.....		: Alain Jorge Acuña
--	Created at		: 29/07/2023
--	Modified by  	: ...
-- ===================================================================================== --
*/
CREATE    PROCEDURE [dbo].[Usp_HR_DelRol]
    -- Add the parameters for the stored procedure here
    @role_id INT,
    @prp_mensaje varchar(250) output
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        DELETE FROM dbo.Roles WHERE dbo.Roles.role_id = @role_id
            SET @prp_mensaje = 'The role has been successfully deleted!'
    COMMIT
	END TRY
	BEGIN CATCH
    ROLLBACK
        SET @prp_mensaje ='Could not delete role %s'		
		--SET @nIdLogExcAG = -1
 		RAISERROR (@prp_mensaje,1,16,@role_id) 
    END CATCH
	--END
END