import { BrowserRouter, Routes, Route } from "react-router-dom";
import WelcomePage from "./Pages/WelcomePage";
import LoginPage from "./Pages/LoginPage";
import RegisterPage from "./Pages/RegisterPage";
import HomePage from "./Pages/HomePage";
import ProtectedRoute from "./Components/ProtectedRoute";
import HomeLayout from "./Pages/HomeLayout ";
import PersonalChatsPage from "./Pages/PersonalChatsPage";
import PersonalChatPage from "./Pages/PersonalChatPage";
import NotFoundPage from "./Pages/NotFountPage";
import GroupsPage from "./Pages/GroupsPage";
import CreateGroupForm from "./Pages/CreateGroupForm";
import GroupDetailsPage from "./Pages/GroupDetailsPage";

function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<WelcomePage />} />
                <Route path="/login" element={<LoginPage />} />
                <Route path="/register" element={<RegisterPage />} />

                <Route element={<ProtectedRoute />}>
                    <Route path="/home" element={<HomeLayout />}>
                        <Route index element={<HomePage />} />
                        <Route path="chats" element={<PersonalChatsPage />} />
                        <Route path="chats/:idPersonalChat" element={<PersonalChatPage />} />
                        <Route path="groups" element={<GroupsPage />} />
                        <Route path="groups/:id" element={<GroupDetailsPage />} />
                        <Route path="groups/create" element={<CreateGroupForm />} />
                        
                        <Route path="*" element={<NotFoundPage />} />
                    </Route>
                </Route>

                {/* �������� ������ ��� ������ */}
                {/*<Route element={<RoleProtectedRoute allowedRoles={['Admin']} />}>*/}
                {/*    <Route path="/admin" element={<AdminPage />} />*/}
                {/*</Route>*/}

            </Routes>
        </BrowserRouter>
    );

}
export default App;